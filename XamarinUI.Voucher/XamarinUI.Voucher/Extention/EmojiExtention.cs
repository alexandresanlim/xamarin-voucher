using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinUI.Voucher.Extention
{
    public static class EmojiExtention
    {
        private static List<string> EmojiHappy
        {
            get
            {
                return new List<string>
                {
                    "😀",
                    "😁",
                    "😉",
                    "🤩",
                    "😄",
                    "🙂",
                    "🎉",
                    "😝",
                    "👏",
                    "🤙",
                    "😎",
                    "🙌"
                };
            }
        }

        private static List<string> EmojiMoney
        {
            get
            {
                return new List<string>
                {
                    "🤑",
                    "💰",
                    "💵",
                    "💲",
                };
            }
        }

        public static string GetARandomEmojiHappy { get { return EmojiHappy.PickRandom(); } }

        public static string GetARandomEmojiMoney { get { return EmojiMoney.PickRandom(); } }
    }
}
