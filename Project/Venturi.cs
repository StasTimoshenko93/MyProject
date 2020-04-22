using System;


namespace Project
{
    [Serializable]
    public class Venturi
    {
        private string _name;
        private ValueClass _value;
        private DateTime _birthayDate;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!value.Equals(_name))
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        _name = value;
                    }
                    else if (value == null)
                    {
                        throw new ArgumentNullException($"{nameof(Name)} не может быть пустым", nameof(Name));
                    }
                    else
                    {
                        throw new ArgumentException($"{nameof(Name)} не может быть пустой или содержать только пробелы", nameof(Name));
                    }
                }
            }
        }
        public ValueClass Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value ?? throw new ArgumentNullException($"{nameof(Value)} не может быть пустым", nameof(Value));
            }
        }
 
        public DateTime BirthayDate
        {
            get 
            {
                return _birthayDate;
            }
            set 
            {

                if (value == DateTime.MinValue)
                {
                    throw new Exception($"{nameof(BirthayDate)} Ошибка с датой");
                }

               _birthayDate = value;
            } 
        }

        public Venturi(string name, ValueClass value, DateTime birthday)
        {
            Name = name;
            Value = value;
            BirthayDate = birthday;
        }
        public Venturi(string name)
        {
           
            Name = name;
        }
    }
}
