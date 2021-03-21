
using Core.Utilities.Results.Abstruct;
using Entities.Concrute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstruct
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<Car> GetById(int carId);
        IResult CheckIfCarAlreadyExist(int carId); 
        //uygulamalarda tutarlılığı koumak için kullanılır.
        //Örneğin para transferinde parayı gmöderenin hesabından gönderdiği para kadar tutar silinir ve
        //parayı alan kişinin hesabına gmnderilen para kadar tutar eklenir.Eğer bu işlemler sırasında
        //sistem hata verirse yapılan işlemler geri alınması lazım bu geri almaa transaction denir. 
        //Veritabanı İşi !!!! 
        IResult AddTransactionalTest(Car car);
    }
}
