using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MpdBaileyTechnology.Shared.WPF.Service.Services;

namespace MpdBaileyTechnology.Shared.WPF.Service.Mock
{
    public class MockTimerService : ITimerService
    {
        public event EventHandler Tick;
        public Action StartCallBack { get; set; }
        public Action StopCallBack { get; set; }

        public TimeSpan Interval { get; set; }
        public bool IsEnabled{get;set;}

        public void Start()
        {
            if (StartCallBack!=null)
            {
                StartCallBack();
            }
        }

        public void Stop()
        {
            if(StopCallBack!=null)
            {
                StopCallBack();
            }
        }

        public void OnTick()
        {
            if (Tick!=null)
            {
                Tick(this, EventArgs.Empty);
            }
        }
    }
}
