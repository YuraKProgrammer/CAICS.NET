using CAICS.Models;

namespace CAICS.PaymentsStorage
{
    public interface IPaymentsStorage
    {
        public void Save(Payment payment);
        public List<Payment> LoadAll();
        public void Remove(Payment payment);
    }
}