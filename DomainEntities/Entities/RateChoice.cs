using System;
using System.Collections.Generic;
using System.Text;

namespace DomainEntities
{
    public class RateChoice
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Value { get; set; }

        public void UpdateTextAndValue(string text, int value)
        {
            Text = text;
            Value = value;
            //todo: update through service
        }

    }
}
