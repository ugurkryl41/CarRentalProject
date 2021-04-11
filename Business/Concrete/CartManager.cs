using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        ICartDal _cartDal;

        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public IResult Add(Cart cart)
        {
            _cartDal.Add(cart);
            return new SuccessResult("Kart Ekleme Başarılı..");
        }

        public IResult Delete(Cart cart)
        {
            _cartDal.Delete(cart);
            return new SuccessResult("Kart Silme Başarılı..");
        }

        public IDataResult<Cart> Get(int id)
        {
            var result = _cartDal.Get(p => p.Id == id);
            return new SuccessDataResult<Cart>(result);
        }

        public IDataResult<List<Cart>> GetAll()
        {
           
            return new SuccessDataResult<List<Cart>>(_cartDal.GetAll().ToList());
        }

        public IDataResult<List<Cart>> GetAllByCustomerId(int customerId)
        {
            var result = _cartDal.GetAll(p => p.CustomerId == customerId);
            return new SuccessDataResult<List<Cart>>(result);
        }

        public IResult Update(Cart cart)
        {
            _cartDal.Update(cart);
            return new SuccessResult("Kart Güncelleme Başarılı..");
        }
    }
}
