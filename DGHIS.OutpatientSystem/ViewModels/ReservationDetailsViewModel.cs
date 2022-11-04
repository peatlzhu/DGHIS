using DGHIS.Core.Models;
using DGHIS.Core.ViewModels;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGHIS.OutpatientSystem.ViewModels
{
    /// <summary>
    /// 掛號記錄詳情
    /// </summary>
    public class ReservationDetailsViewModel : BaseViewModel
    {
        /// <summary>
        /// 掛號記錄詳情
        /// </summary>
        /// <param name="container"></param>
        public ReservationDetailsViewModel(IContainerExtension container) : base(container)
        {

        }

        public ReservationOutputDto Reservation
        {
            get
            {
                return this.GetContext<ReservationOutputDto>();
            }
        }
    }
}
