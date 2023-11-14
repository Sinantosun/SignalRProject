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
            _sliderDal.Delete(t);
        }

        public Slider TgetById(int id)
        {
            return _sliderDal.getById(id);
        }

        public List<Slider> TGetList()
        {
            return _sliderDal.GetList();
        }

        public void TInsert(Slider t)
        {
            _sliderDal.Insert(t);
        }

        public void TUpdate(Slider t)
        {
            _sliderDal.Update(t);
        }
    }
}
