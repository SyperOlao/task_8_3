﻿using System.Collections.Generic;

/*Предусмотреть возможность
выполнения следующих операций: реализация товара(партии товаров) с указанием
даты совершения операции, подсчета выручки за указанный период времени,
поступления новой партии товара.*/

namespace task_8_3
{
    class Store
    {
        private List<Product> products = new List<Product>();
        private List<Date> date = new List<Date>();

        public void BuyNewProducts(List<Product> products, string date)
        {
            int money = 0;
            foreach (var item in products)
            {
                this.products.Add(item);
                money -= item.WholesalePrice; 
            }

            this.date.Add(new Date(money, date)); 
        }

        public void SellProducts(List<Product> products, string date)
        {
            int money = 0;
            foreach (var item in products)
            {
                this.products.Remove(item);
                money += item.MarketPrice; 
            }
            this.date.Add(new Date(money, date)); 
        }

        public int Revenue(string data1, string data2) //Выручка по периодам 
        {
            int revenue = 0;

            return revenue;
        }


    }
}
