using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace XamarinUI.Voucher.Models
{
    public class VoucherValue
    {
        public VoucherValueType Type { get; set; }

        public int ValueFromType { get; set; }

        public string ValueFromTypePresentation => Type == VoucherValueType.Money ? ValueFromType.ToString("N") : ValueFromType.ToString() + "%";

        public string CurrencySymbol => Type == VoucherValueType.Money ? NumberFormatInfo.CurrentInfo.CurrencySymbol : "";

        public string PercentMsg => Type == VoucherValueType.Percent ? "OFF" : "";
    }

    public enum VoucherValueType
    {
        Money,
        Percent
    }
}
