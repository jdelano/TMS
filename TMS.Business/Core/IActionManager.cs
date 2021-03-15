using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.Business.Core
{
    public interface IActionManager
    {
        void Create(BaseEntity entity);
        void Update(BaseEntity entity);
        void Delete(BaseEntity entity);
        IEnumerable<BaseEntity> GetAll();
        IUnitOfWork UnitOfWork { get;  }
        void SaveChanges();
    }
}
