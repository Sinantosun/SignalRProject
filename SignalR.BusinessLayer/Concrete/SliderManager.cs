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
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void TDelete(Slider t)
        {
            throw new NotImplementedException();
        }

        public Slider TgetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Slider> TGetList()
        {
            return _sliderDal.GetList();
        }

        public void TInsert(Slider t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Slider t)
        {
            throw new NotImplementedException();
        }
    }
}
