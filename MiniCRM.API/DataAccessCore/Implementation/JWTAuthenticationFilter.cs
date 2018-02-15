//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataAccessCore.Implementation
//{
//    public class JWTAuthenticationFilter : AuthorizationFilterAttribute
//    {

//        public override void OnAuthorization(HttpActionContext filterContext)
//        {

//            if (!IsUserAuthorized(filterContext))
//            {
//                ShowAuthenticationError(filterContext);
//                return;
//            }
//            base.OnAuthorization(filterContext);
//        }
//    }
//}
