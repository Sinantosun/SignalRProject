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
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _IbookingDal;
        public BookingManager(IBookingDal bookingDal)
        {
            _IbookingDal = bookingDal;
        }

        public void TbookingStatusDescriptionApprove(int id)
        {
            _IbookingDal.bookingStatusDescriptionApprove(id);
        }

        public void TbookingStatusDescriptionCancel(int id)
        {
            _IbookingDal.bookingStatusDescriptionCancel(id);
        }

        public void TDelete(Booking t)
        {
            _IbookingDal.Delete(t);
        }

        public Booking TgetById(int id)
        {
            return _IbookingDal.getById(id);
        }

        public List<Booking> TGetList()
        {
            return _IbookingDal.GetList();
        }

        public void TInsert(Booking t)
        {
            _IbookingDal.Insert(t);
        }

        public void TUpdate(Booking t)
        {
            _IbookingDal.Update(t);
        }
    }
}
