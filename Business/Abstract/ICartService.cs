using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICartService
    {
        IDataResult<List<Cart>> GetAll();
        IDataResult<Cart> Get(int id);

        IResult Add(Cart cart);
        IResult Update(Cart cart);
        IResult Delete(Cart cart);

        IDataResult<List<Cart>> GetAllByCustomerId(int customerId);
    }
}
