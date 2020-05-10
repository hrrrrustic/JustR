using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using JustR.Desktop.Controls;
using JustR.Models.Dto;
using JustR.Models.Entity;

namespace JustR.Desktop
{
    public class TestConverter : IValueConverter
    {
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            DialogPreviewDto dto = (DialogPreviewDto) value;
            var control = new DialogPreviewControl();
            control.DialogName.Text = dto.DialogName;

            return control;
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
