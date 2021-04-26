using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiport_v2.classFolder
{
    class errorClass
    {
        public static void except(Exception e)
        {
            try
            {
                var error = classFolder.dbClass.entities.Status.FirstOrDefault(x => x.Name == e.GetType().ToString());
                var errorTime = classFolder.dbClass.entities.TimeStatus.FirstOrDefault(x => x.Id == MainWindow.TimeIn);
                if (error != null)
                {
                    errorTime.idStatus = error.Id;
                    classFolder.dbClass.entities.SaveChanges();
                }
                else
                {
                    errorTime.idStatus = 9;
                    classFolder.dbClass.entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
               //except(ex);
            }
        }
    }
}
