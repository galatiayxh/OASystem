﻿ 

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
	public partial interface IDBSession
    {

	
		IActionInfoDal ActionInfoDal{get;set;}
	
		IDepartmentDal DepartmentDal{get;set;}
	
		IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal{get;set;}
	
		IRoleInfoDal RoleInfoDal{get;set;}
	
		IUserInfoDal UserInfoDal{get;set;}
	}	
}