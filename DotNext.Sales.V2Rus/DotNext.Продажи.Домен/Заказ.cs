using System;

namespace DotNext.Продажи.Домен
{
    public class Заказ
    {
        public long Код { get; set; }
        public long КодКлиента { get; set; }
        public long КодСобытия { get; set; }
        public decimal Цена { get; set; }
        public DateTime ДатаЗаказа { get; set; }
        public int КодСтатуса { get; set; }
        public СтатусЗаказа Статус { get; set; }

        #region V2
        public decimal Скидка { get; set; }
        public decimal ИтоговаяЦена { get; set; }

        public void ПрименитьСкидку(decimal скидка)
        {
            Скидка = скидка;
            ИтоговаяЦена = Цена * (100 - скидка) / 100;
        }
        #endregion
    }
}
