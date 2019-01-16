using CommonStuff;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace M10_Collections
{
    public class DictionaryLab
    {
        ConsoleHelper ch = new ConsoleHelper();

        public void Run()
        {
            Dictionary<int, string> products = BuildProductDictionary();
            DisplayProductDictionary(products);
        }

        private void DisplayProductDictionary(Dictionary<int, string> products)
        {
            foreach(KeyValuePair<int,string> product in products)
            {
                ch.WriteDark($"Product id={product.Key} and name={product.Value}");
            }
        }

        private Dictionary<int, string> BuildProductDictionary()
        {
            string answer = "";

            var productDic = new Dictionary<int, string>();

            while (true)
            {
                answer = ch.AskForString("Enter product id and name:");

                if (string.IsNullOrWhiteSpace(answer))
                    return productDic;

                answer = answer.Trim();

                if (!ValidInput(answer))
                {
                    ch.ErrorMessage("Invalid input");
                    continue;
                }

                int productId = int.Parse(answer.Split(',')[0]);
                string productName = answer.Split(',')[1];

                if (productDic.ContainsKey(productId))
                    ch.ErrorMessage($"The product list already contains the id {productId}");
                else
                    productDic.Add(productId, productName);
            }
        }

        private bool ValidInput(string answer)
        {
            return Regex.IsMatch(answer, @"^\d+,[a-z ]+$", RegexOptions.IgnoreCase);
        }
    }
}