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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _TestimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _TestimonialDal = testimonialDal;
        }

        public void TDelete(Testimonial t)
        {
            _TestimonialDal.Delete(t);
        }

        public Testimonial TgetById(int id)
        {
            return _TestimonialDal.getById(id);
        }

        public List<Testimonial> TGetList()
        {
            return _TestimonialDal.GetList();
        }

        public void TInsert(Testimonial t)
        {
            _TestimonialDal.Insert(t);
        }

        public void TUpdate(Testimonial t)
        {
            _TestimonialDal.Update(t);
        }
    }
}
