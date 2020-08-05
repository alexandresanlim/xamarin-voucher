using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XamarinUI.Voucher.Base;
using XamarinUI.Voucher.Extention;

namespace XamarinUI.Voucher
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            LoadDataCommand.Execute(null);
        }

        public Command LoadDataCommand => new Command(async () =>
        {
            Vouchers = new ObservableCollection<Models.Voucher>();
            var voucherFromService = Models.Voucher.GetList().OrderByDescending(x => x.ValidAt);

            foreach (var item in voucherFromService)
            {
                Vouchers.Add(item);
            }

            await LoadCurrentBalance();
        });

        private async Task LoadCurrentBalance()
        {
            CurrentBalance = "";

            var balance = Vouchers.Where(x => x.Value.Type == Models.VoucherValueType.Money).Sum(x => x.Value.ValueFromType);

            // Animated current balance
            for (int i = 0; i < balance; i++)
            {
                await Task.Delay(10);

                CurrentBalance = i.ToString("C");
            }
        }

        public Command SetNewVoucherCommand => new Command(async () =>
        {
            var vocherCode = await DisplayPromptAsync("New voucher", "Set your new voucher code: ", 6);

            if (!string.IsNullOrEmpty(vocherCode))
            {
                var voucherAdd = new Models.Voucher
                {
                    CreateAt = DateTime.Now,
                    Emoji = EmojiExtention.GetARandomEmojiHappy,
                    ValidAt = DateTime.Now.AddDays(15),
                    Value = new Models.VoucherValue
                    {
                        Type = Models.VoucherValueType.Money,
                        ValueFromType = 15
                    }
                };

                Vouchers.Insert(0, voucherAdd);
            }
        });

        private ObservableCollection<Models.Voucher> _vouchers;
        public ObservableCollection<Models.Voucher> Vouchers
        {
            set { SetProperty(ref _vouchers, value); }
            get { return _vouchers; }
        }

        private string _currentBalance;
        public string CurrentBalance
        {
            set { SetProperty(ref _currentBalance, value); }
            get { return _currentBalance; }
        }
    }
}
