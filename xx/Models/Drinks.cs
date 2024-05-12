using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace xx.Models
{
	public partial  class Drinks : ObservableObject
	{
		public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public string Calories { get; set; }


        [ObservableProperty, NotifyPropertyChangedFor(nameof(Amount))]
        private int _cartQuantity;


        public double Amount => CartQuantity * Price;

        public Drinks Clone() => MemberwiseClone() as Drinks;




    }
}

