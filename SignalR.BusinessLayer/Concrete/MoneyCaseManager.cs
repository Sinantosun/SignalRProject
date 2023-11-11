using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccsessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class MoneyCaseManager : IMoneyCaseService
    {
        private readonly IMoneyCaseDal _moneyCaseDal;

        public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
        {
            _moneyCaseDal = moneyCaseDal;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void TDelete(MoneyCase t)
        {
            throw new NotImplementedException();
        }

        public MoneyCase TgetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<MoneyCase> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(MoneyCase t)
        {
            throw new NotImplementedException();
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        public decimal TTotalMoneyCaseAmount()
        {
            return _moneyCaseDal.TotalMoneyCaseAmount();
        }

        public void TUpdate(MoneyCase t)
        {
            throw new NotImplementedException();
        }
    }
}
