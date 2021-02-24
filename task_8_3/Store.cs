﻿using System.Collections.Generic;
using System.IO;

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

        public int Revenue(string date1, string date2) //Выручка по периодам 
        {
            int revenue = 0;
            foreach (var item in date)
            {
                if (DateCalculation.IsInDates(DateCalculation.DateToNumber(date1), DateCalculation.DateToNumber(item.DateOfOperation), DateCalculation.DateToNumber(date2))){
                    revenue += item.Money;
                }
            }
            return revenue;
        }
        
        public Store(string path)
        {
            Product temp = new Product();
            string[] file = File.ReadAllLines(path);
            for (int i = 0; i < file.Length-3; i+=3)
            {
                products.Add(new Product(file[i], int.Parse(file[i+1]), int.Parse(file[i+2])));
            }
        }

        public List<Product> GetProducts()
        {
            return products; 
        }
    }
}