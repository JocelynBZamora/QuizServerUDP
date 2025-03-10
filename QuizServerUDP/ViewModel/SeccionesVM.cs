using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QuizzServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;


namespace QuizServerUDP.ViewModel
{
    public partial class SeccionesVM:ObservableRecipient
    {
        public SeccionesVM()
        {
            IsActive = true;
        }
        [RelayCommand]
        public void IrPReguntas(string seccion)
        {
            NavegacionModel model = new NavegacionModel()
            {
                seccion = seccion,
                vista = "Preguntas"
            };
            Messenger.Send(model);
        }
    }
}
