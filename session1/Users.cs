//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace session1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public int Iduser { get; set; }
        public string username { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int idRole { get; set; }
    
        public virtual Role Role { get; set; }
    }
}
