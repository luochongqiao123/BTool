﻿using System.Threading;
using TI.Toolbox;

namespace BTool
{
	public class ThreadMgr
	{
		public RspDataInThread rspDataIn;
		public TxDataOutThread txDataOut;
		public RxDataInThread rxDataIn;
		public RxTxMgrThread rxTxMgr;

		public ThreadMgr(DeviceForm deviceForm)
		{
			rspDataIn = new RspDataInThread(deviceForm);
			txDataOut = new TxDataOutThread();
			rxDataIn = new RxDataInThread(deviceForm);
			rxTxMgr = new RxTxMgrThread();
		}

		~ThreadMgr()
		{
			ExitThreads();
		}

		public void Init(DeviceForm deviceForm)
		{
			txDataOut.InitThread(deviceForm);
			rxDataIn.InitThread(deviceForm);
		}

		public bool StopThreads()
		{
			rspDataIn.threadCtrl.ControlThread(ThreadControl.ThreadCtrl.Stop);
			txDataOut.threadCtrl.ControlThread(ThreadControl.ThreadCtrl.Stop);
			rxDataIn.threadCtrl.ControlThread(ThreadControl.ThreadCtrl.Stop);
			rxTxMgr.threadCtrl.ControlThread(ThreadControl.ThreadCtrl.Stop);
			return true;
		}

		public bool PauseThreads()
		{
			rspDataIn.threadCtrl.ControlThread(ThreadControl.ThreadCtrl.Pause);
			txDataOut.threadCtrl.ControlThread(ThreadControl.ThreadCtrl.Pause);
			rxDataIn.threadCtrl.ControlThread(ThreadControl.ThreadCtrl.Pause);
			rxTxMgr.threadCtrl.ControlThread(ThreadControl.ThreadCtrl.Pause);
			return true;
		}

		public bool ResumeThreads()
		{
			rspDataIn.threadCtrl.ControlThread(ThreadControl.ThreadCtrl.Resume);
			txDataOut.threadCtrl.ControlThread(ThreadControl.ThreadCtrl.Resume);
			rxDataIn.threadCtrl.ControlThread(ThreadControl.ThreadCtrl.Resume);
			rxTxMgr.threadCtrl.ControlThread(ThreadControl.ThreadCtrl.Resume);
			return true;
		}

		public bool ExitThreads()
		{
			if (rspDataIn != null)
				rspDataIn.threadCtrl.ControlThread(ThreadControl.ThreadCtrl.Exit);
			if (txDataOut != null)
				txDataOut.threadCtrl.ControlThread(ThreadControl.ThreadCtrl.Exit);
			if (rxDataIn != null)
				rxDataIn.threadCtrl.ControlThread(ThreadControl.ThreadCtrl.Exit);
			if (rxTxMgr != null)
				rxTxMgr.threadCtrl.ControlThread(ThreadControl.ThreadCtrl.Exit);
			return true;
		}

		public bool ClearQueues()
		{
			rspDataIn.dataQ.ClearQ();
			txDataOut.dataQ.ClearQ();
			rxDataIn.dataQ.ClearQ();
			rxTxMgr.dataQ.ClearQ();
			return true;
		}

		public bool WaitForPause()
		{
			bool flag = true;
			do
			{
				Thread.Sleep(100);
			}
			while (!rspDataIn.threadCtrl.CheckForThreadIdle(ThreadControl.CheckIdleModes.Paused)
				|| !txDataOut.threadCtrl.CheckForThreadIdle(ThreadControl.CheckIdleModes.Paused)
				|| !rxDataIn.threadCtrl.CheckForThreadIdle(ThreadControl.CheckIdleModes.Paused)
				|| !rxTxMgr.threadCtrl.CheckForThreadIdle(ThreadControl.CheckIdleModes.Paused)
				);
			return flag;
		}

		public bool CheckForIdle()
		{
			return (rspDataIn.dataQ.GetQLength() <= 0
			&& txDataOut.dataQ.GetQLength() <= 0
			&& (rxDataIn.dataQ.GetQLength() <= 0
			&& rxTxMgr.dataQ.GetQLength() <= 0));
		}
	}
}
