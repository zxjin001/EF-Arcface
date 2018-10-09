using Company.DAL;
using Company.IBLL;
using Company.IDAL;
using Company.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL
{
    public partial class Base_OrganizeService : BaseService<Base_Organize>, IBase_OrganizeService
    {
        public override void SetDal()
        {
            Dal = DALContainer.Container.Resolve<Base_OrganizeDAL, IBase_OrganizeDAL>(); 
        }
    }
}
