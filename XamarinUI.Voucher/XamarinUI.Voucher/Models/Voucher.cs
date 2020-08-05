using System;
using System.Collections.Generic;
using System.Text;
using XamarinUI.Voucher.Extention;

namespace XamarinUI.Voucher.Models
{
    public class Voucher
    {
        public Voucher()
        {
            Value = new VoucherValue();
        }

        public DateTime CreateAt { get; set; }

        public DateTime ValidAt { get; set; }

        public VoucherValue Value { get; set; }

        public string CreateAtPresentation => CreateAt.ToString("dd MMMM");

        public string ValidAtPresentation => ValidAt.ToString("dd MMMM");

        public string Emoji { get; set; }

        public bool IsExpired => ValidAt.Date < DateTime.Today.Date;

        public static List<Voucher> GetList()
        {
            return new List<Voucher>
            {
                new Voucher
                {
                    CreateAt = DateTime.Now,
                    ValidAt = DateTime.Now.AddDays(-10),
                    Value = new VoucherValue
                    {
                        Type = VoucherValueType.Money,
                        ValueFromType = 10
                    },
                    Emoji = EmojiExtention.GetARandomEmojiHappy
                },
                new Voucher
                {
                    CreateAt = DateTime.Now,
                    ValidAt = DateTime.Now.AddDays(-18),
                    Value = new VoucherValue
                    {
                        Type = VoucherValueType.Percent,
                        ValueFromType = 5
                    },
                    Emoji = EmojiExtention.GetARandomEmojiHappy
                },
                new Voucher
                {
                    CreateAt = DateTime.Now.AddDays(-8),
                    ValidAt = DateTime.Now.AddDays(12),
                    Value = new VoucherValue
                    {
                        Type = VoucherValueType.Percent,
                        ValueFromType = 10
                    },
                    Emoji = EmojiExtention.GetARandomEmojiHappy
                },
                new Voucher
                {
                    CreateAt = DateTime.Now,
                    ValidAt = DateTime.Now.AddDays(-10),
                    Value = new VoucherValue
                    {
                        Type = VoucherValueType.Money,
                        ValueFromType = 10
                    },
                    Emoji = EmojiExtention.GetARandomEmojiHappy
                },
                new Voucher
                {
                    CreateAt = DateTime.Now.AddDays(-15),
                    ValidAt = DateTime.Now.AddDays(8),
                    Value = new VoucherValue
                    {
                        Type = VoucherValueType.Percent,
                        ValueFromType = 15
                    },
                    Emoji = EmojiExtention.GetARandomEmojiHappy
                },
                new Voucher
                {
                    CreateAt = DateTime.Now,
                    ValidAt = DateTime.Now.AddDays(5),
                    Value = new VoucherValue
                    {
                        Type = VoucherValueType.Money,
                        ValueFromType = 10
                    },
                    Emoji = EmojiExtention.GetARandomEmojiHappy
                },
                new Voucher
                {
                    CreateAt = DateTime.Now.AddDays(-5),
                    ValidAt = DateTime.Now.AddDays(8),
                    Value = new VoucherValue
                    {
                        Type = VoucherValueType.Money,
                        ValueFromType = 30
                    },
                    Emoji = EmojiExtention.GetARandomEmojiHappy
                }
            };
        }
    }
}
