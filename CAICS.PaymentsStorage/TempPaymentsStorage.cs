using CAICS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CAICS.PaymentsStorage
{
    public class TempPaymentsStorage : IPaymentsStorage
    {
        private List<Payment> Payments = new List<Payment>();
        private BinaryFormatter formatter = new BinaryFormatter();
        private const string fileName = "D:\\Payments.dat";

        public List<Payment> LoadAll()
        {
            if (File.Exists(fileName))
            {
                string[] stroki = File.ReadAllLines(fileName);
                if (stroki.Length > 0)
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                    {
                        Payments = (List<Payment>)formatter.Deserialize(fs);
                    }
                }
                else
                {
                    Payments = new List<Payment>();
                }
            }
            else
            {
                Payments = new List<Payment>();
            }
            return Payments;
        }

        public void Save(Payment payment)
        {
            LoadAll();
            Payments.Add(payment);
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                fs.SetLength(0);
                formatter.Serialize(fs, Payments);
            }
        }

        public void Remove(Payment payment)
        {
            LoadAll();
            Payments.Remove(Payments.Where(pa => pa.Name == payment.Name && pa.DateTime == payment.DateTime && pa.Value == payment.Value).FirstOrDefault());
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                fs.SetLength(0);
                formatter.Serialize(fs, Payments);
            }
        }
    }
}
