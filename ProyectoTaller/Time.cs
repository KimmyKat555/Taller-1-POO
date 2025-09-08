namespace Proyecto1
{
    public class Time
    {
        //Campos privados para almacenar la hora, minuto, segundo y mlisegundo
        private int _hour;
        private int _minute;
        private int _second;
        private int _milisecond;

        //Variable estática para guardar errores
        public static string LastError = "";

        //Propiedad de horas, minutos, segundos y miliseg con validación de su rango
        public int Hour
        {
            get { return _hour; }
            set
            {
                if (value < 0 || value > 23)
                {
                    LastError = "The hour " + value + " is not valid";
                    _hour = 0;  // valor por defecto
                }
                else _hour = value;
            }
        }
        public int Minute
        {
            get { return _minute; }
            set
            {
                if (value < 0 || value > 59)
                {
                    LastError = "The minute " + value + " is not valid";
                    _minute = 0;
                }
                else _minute = value;
            }
        }
        public int Second
        {
            get { return _second; }
            set
            {
                if (value < 0 || value > 59)
                {
                    LastError = "The second " + value + " is not valid";
                    _second = 0;
                }
                else _second = value;
            }
        }
        public int Milisecond
        {
            get { return _milisecond; }
            set
            {
                if (value < 0 || value > 999)
                {
                    LastError = "The milisecond " + value + " is not valid";
                    _milisecond = 0;
                }
                else _milisecond = value;
            }
        }
        //Constructor sin parametros
        public Time()
        {
            Hour = 0;
            Minute = 0;
            Second = 0;
            Milisecond = 0;
        }
        //Constructor con hora
        public Time(int hour)
        {
            Hour = hour;
            Minute = 0;
            Second = 0;
            Milisecond = 0;
        }
        //Constructor con horas y minutos
        public Time(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
            Second = 0;
            Milisecond = 0;
        }
        //Constructor con hora, minuto y segundo
        public Time(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            Milisecond = 0;
        }
        //Constructor con hora, minuto, segundo y milisegundo
        public Time(int hour, int minute, int second, int milisecond)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            Milisecond = milisecond;
        }
        //Método para mostrar la hora en formato 12h con AM/PM
        public override string ToString()
        {
            int h = Hour;           // hora original
            string ampm = "AM";     // asumir AM por defecto

            if (h >= 12)             // si es mayor o igual a 12, es PM
                ampm = "PM";

            if (h > 12)              // ajustar a formato 12h
                h = h - 12;

            if (h == 0)              // si es 0, se muestra como 12
                h = 12;

            // Convertir a dos dígitos y milisegundos a tres dígitos
            string hh = h.ToString("D2");
            string mm = Minute.ToString("D2");
            string ss = Second.ToString("D2");
            string ms = Milisecond.ToString("D3");

            // Formato HH:MM:SS.mmm AM/PM
            return hh + ":" + mm + ":" + ss + "." + ms + " " + ampm;
        }
        //Convertir a milisegundos desde medianoche
        public int ToMilliseconds()
        {
            return (((Hour * 60 + Minute) * 60 + Second) * 1000) + Milisecond;
        }
        //Convetir a segundos desde media noche
        public int ToSeconds()
        {
            return (Hour * 3600) + (Minute * 60) + Second;
        }
        //Convertir a minutos desde media noche
        public int ToMinutes()
        {
            return (Hour * 60) + Minute;
        }
        //Metodo para sumar el tiempo
        public Time Add(Time t)
        {
            //Sumar cada campo
            int newMs = this.Milisecond + t.Milisecond;
            int newSec = this.Second + t.Second;
            int newMin = this.Minute + t.Minute;
            int newHour = this.Hour + t.Hour;

            if (newMs >= 1000)
            {
                newMs -= 1000;
                newSec += 1; //pasar un segundo extra
            }
            if (newSec >= 60)
            {
                newSec -= 60;
                newMin += 1; //pasar un minuto extra
            }
            // Ajustar minutos
            if (newMin >= 60)
            {
                newMin -= 60;
                newHour += 1; // pasar una hora extra
            }

            // Ajustar horas (no borramos el exceso, lo usamos en IsOtherDay)
            if (newHour >= 24)
                newHour -= 24;

            // Crear y devolver un nuevo objeto Time con la suma
            return new Time(newHour, newMin, newSec, newMs);
        }

        //Método que verifica si al sumar la hora actual con otra se pasa al siguiente día
        public bool IsOtherDay(Time other)
        {
            //Milisegundos totales de la hora actual
            int totalThis = this.ToMilliseconds();

            //Milisegundos totales de la otra hora
            int totalOther = other.ToMilliseconds();

            //Milisegundos en un día (24h)
            int dayInMs = 24 * 60 * 60 * 1000;

            //Sumamos ambas horas
            int totalSum = totalThis + totalOther;

            //Si la suma es mayor o igual a un día, se pasa al siguiente día
            if (totalSum >= dayInMs)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ValidHour(int value) { return value >= 0 && value <= 23; }
        private bool ValidMinute(int value) { return value >= 0 && value <= 59; }
        private bool ValidSecond(int value) { return value >= 0 && value <= 59; }
        private bool ValidMilisecond(int value) { return value >= 0 && value <= 999; }
    }
}
