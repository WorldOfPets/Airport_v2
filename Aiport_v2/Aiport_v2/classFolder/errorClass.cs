using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiport_v2.classFolder
{
    class errorClass
    {
        public static void except(Exception e)//Обработка ошибки, отправка ее в базу данных и сообщение пользователю 
        {
            try
            {
                pageFolder.ErrorWindow errorWindow = new pageFolder.ErrorWindow(e.Message);
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
                errorWindow.Show();
            }
            catch (Exception ex)
            {
                //Чисто поржать
               //except(ex);
            }
        }
    }
}
