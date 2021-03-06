﻿using TI.Toolbox;

namespace BTool
{
	public class DisplayTxCmds
	{
		public DeviceForm.DisplayMsgDelegate DisplayMsgCallback;
		public DeviceForm.DisplayMsgTimeDelegate DisplayMsgTimeCallback;

		private DisplayCmdUtils dspCmdUtils = new DisplayCmdUtils();
		private DataUtils dataUtils = new DataUtils();
		private DeviceFormUtils devUtils = new DeviceFormUtils();
		private const string moduleName = "DisplayTxCmds";

		public void DisplayTxCmd(TxDataOut txDataOut, bool displayBytes)
		{
			ushort opCode = txDataOut.cmdOpcode;
			byte[] data = txDataOut.data;
			byte packetType = data[0];
			byte num1 = data[3];
			string str1 = string.Empty;
			string str2 = string.Empty;
			string msg1 = str1 + string.Format("-Type\t\t: 0x{0:X2} ({1:S})\n-Opcode\t\t: 0x{2:X4} ({3:S})\n-Data Length\t: 0x{4:X2} ({5:D}) byte(s)\n", packetType, devUtils.GetPacketTypeStr(packetType), opCode, devUtils.GetOpCodeName(opCode), num1, num1);
			byte[] addr = new byte[6];
			string msg2 = string.Empty;
			int index1 = 4;
			byte bits1 = (byte)0;
			ushort bits2 = (ushort)0;
			bool dataErr = false;
			ushort num2 = opCode;

			if (num2 <= 64798U)
			{
				if (num2 <= 64532U)
				{
					switch (num2)
					{
						case 5125:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							goto label_284;
						case 8208:
						case 64521:
						case 64523:
						case 64526:
						case 64528:
							goto label_284;

						case 8209:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
								msg1 += string.Format(" AddressType\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetLEAddressTypeStr(bits1)) + string.Format(" DeviceAddr\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, (int)num1 + 4 - index1, ref dataErr));
							goto label_284;

						case 8210:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
								msg1 += string.Format(" AddressType\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetLEAddressTypeStr(bits1)) + string.Format(" DeviceAddr\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, (int)num1 + 4 - index1, ref dataErr));
							goto label_284;

						case 8211:
							dataUtils.Unload16Bits(data, ref index1, ref bits2, ref dataErr, false);
							if (!dataErr)
							{
								msg1 += string.Format(" Handle\t\t: 0x{0:X4} ({1:D})\n", bits2, bits2);
								dataUtils.Unload16Bits(data, ref index1, ref bits2, ref dataErr, false);
								if (!dataErr)
								{
									msg1 += string.Format(" ConnInterval\t: 0x{0:X4} ({1:D})\n", bits2, bits2);
									dataUtils.Unload16Bits(data, ref index1, ref bits2, ref dataErr, false);
									if (!dataErr)
									{
										msg1 += string.Format(" ConnIntervalMax\t: 0x{0:X4} ({1:D})\n", bits2, bits2);
										dataUtils.Unload16Bits(data, ref index1, ref bits2, ref dataErr, false);
										if (!dataErr)
										{
											msg1 += string.Format(" ConnLatency\t: 0x{0:X4} ({1:D})\n", bits2, bits2);
											dataUtils.Unload16Bits(data, ref index1, ref bits2, ref dataErr, false);
											if (!dataErr)
											{
												msg1 += string.Format(" ConnTimeout\t: 0x{0:X4} ({1:D})\n", bits2, bits2);
												dataUtils.Unload16Bits(data, ref index1, ref bits2, ref dataErr, false);
												if (!dataErr)
												{
													msg1 += string.Format(" MinimumLength\t: 0x{0:X4} ({1:D})\n", bits2, bits2);
													dataUtils.Unload16Bits(data, ref index1, ref bits2, ref dataErr, false);
													if (!dataErr)
														msg1 += string.Format(" MaximumLength\t: 0x{0:X4} ({1:D})\n", bits2, bits2);
												}
											}
										}
									}
								}
							}
							goto label_284;
						case 64512:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
								msg1 += string.Format(" Rx Gain\t\t: 0x{0:X2} ({1:D}) ({2:S})\n", bits1, bits1, devUtils.GetHciExtRxGainStr(bits1));
							goto label_284;
						case 64513:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
								msg1 += string.Format(" Tx Power\t: 0x{0:X2} ({1:D}) ({2:S})\n", bits1, bits1, devUtils.GetHciExtTxPowerStr(bits1));
							goto label_284;
						case 64514:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
								msg1 += string.Format(" Control\t\t: 0x{0:X2} ({1:D}) ({2:S})\n", bits1, bits1, devUtils.GetHciExtOnePktPerEvtCtrlStr(bits1));
							goto label_284;
						case 64515:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
								msg1 += string.Format(" Control\t\t: 0x{0:X2} ({1:D}) ({2:S})\n", bits1, bits1, devUtils.GetHciExtClkDivideOnHaltCtrlStr(bits1));
							goto label_284;
						case 64516:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
								msg1 += string.Format(" Mode\t\t: 0x{0:X2} ({1:D}) ({2:S})\n", bits1, bits1, devUtils.GetHciExtDeclareNvUsageModeStr(bits1));
							goto label_284;
						case 64517:
							str2 = string.Empty;
							msg1 += string.Format(" Key\t\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, 16, ref dataErr));
							if (!dataErr)
							{
								str2 = string.Empty;
								msg1 += string.Format(" Data\t\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, (int)num1 + 4 - index1, ref dataErr));
							}
							goto label_284;
						case 64518:
							str2 = string.Empty;
							msg1 += string.Format(" LocalFeatures\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, (int)num1 + 4 - index1, ref dataErr));
							goto label_284;
						case 64519:
							int num17 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
								msg1 += string.Format(" Control\t\t: 0x{0:X2} ({1:D}) ({2:S})\n", bits1, bits1, devUtils.GetHciExtSetFastTxRespTimeCtrlStr(bits1));
							goto label_284;
						case 64520:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
							{
								msg1 += string.Format(" CW Mode\t: 0x{0:X2} ({1:D}) ({2:S})\n", bits1, bits1, devUtils.GetHciExtCwModeStr(bits1));
								dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
								if (!dataErr)
									msg1 += string.Format(" Tx RF Channel\t: 0x{0:X2} ({1:D})\n", bits1, bits1);
							}
							goto label_284;
						case 64522:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
								msg1 += string.Format(" Rx RF Channel\t: 0x{0:X2} ({1:D})\n", bits1, bits1);
							goto label_284;
						case 64524:
							msg1 += string.Format(" BLEAddress\t: {0:S}\n", devUtils.UnloadDeviceAddr(data, ref addr, ref index1, true, ref dataErr));
							goto label_284;
						case 64525:
							int num20 = dataUtils.Unload16Bits(data, ref index1, ref dataErr, false);
							if (!dataErr)
								msg1 += string.Format(" SCA\t\t: 0x{0:X4} ({1:D})\n", num20, num20);
							goto label_284;
						case 64527:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
								msg1 += string.Format(" Freq Tune\t: 0x{0:X2} ({1:D}) ({2:S})\n", bits1, bits1, devUtils.GetHciExtSetFreqTuneStr(bits1));
							goto label_284;
						case 64529:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
								msg1 += string.Format(" Max Tx Power\t: 0x{0:X2} ({1:D}) ({2:S})\n", bits1, bits1, devUtils.GetHciExtTxPowerStr(bits1));
							goto label_284;
						case 64530:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
							{
								msg1 += string.Format(" PM IO Port\t: 0x{0:X2} ({1:D}) ({2:S})\n", bits1, bits1, devUtils.GetHciExtMapPmIoPortStr(bits1));
								int num6 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
								if (!dataErr)
									msg1 += string.Format(" PM IO Port Pin\t: 0x{0:X2} ({1:D})\n", bits1, bits1);
							}
							goto label_284;
						case 64531:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							goto label_284;
						case 64532:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								int num6 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
								if (!dataErr)
									msg1 += string.Format(" PER Test Cmd\t: 0x{0:X2} ({1:D}) ({2:S})\n", bits1, bits1, devUtils.GetHciExtPERTestCommandStr(bits1));
							}
							goto label_284;
					}
				}
				else
				{
					switch (num2)
					{
						case 64650:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								ushort infoTypes = dataUtils.Unload16Bits(data, ref index1, ref dataErr, false);
								if (!dataErr)
									msg1 += string.Format(" InfoType\t\t: 0x{0:X4} ({1:S})\n", infoTypes, devUtils.GetL2CapInfoTypesStr(infoTypes));
							}
							goto label_284;
						case 64658:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								ushort num6 = dataUtils.Unload16Bits(data, ref index1, ref dataErr, false);
								if (!dataErr)
								{
									msg1 += string.Format(" IntervalMin\t: 0x{0:X4} ({1:D})\n", num6, num6);
									ushort num7 = dataUtils.Unload16Bits(data, ref index1, ref dataErr, false);
									if (!dataErr)
									{
										msg1 += string.Format(" IntervalMax\t: 0x{0:X4} ({1:D})\n", num7, num7);
										ushort num8 = dataUtils.Unload16Bits(data, ref index1, ref dataErr, false);
										if (!dataErr)
										{
											msg1 += string.Format(" SlaveLatency\t: 0x{0:X4} ({1:D})\n", num8, num8);
											ushort num9 = dataUtils.Unload16Bits(data, ref index1, ref dataErr, false);
											if (!dataErr)
												msg1 += string.Format(" TimeoutMultiply\t: 0x{0:X4} ({1:D})\n", num9, num9);
										}
									}
								}
							}
							goto label_284;
						case 64769:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								byte num6 = dataUtils.Unload8Bits(data, ref index1, ref dataErr);
								if (!dataErr)
								{
									msg1 += string.Format(" ReqCode\t: 0x{0:X2} ({1:D})\n", num6, num6);
									dspCmdUtils.AddHandle(data, ref index1, ref dataErr, ref msg1);
									if (!dataErr)
									{
										byte num8 = dataUtils.Unload8Bits(data, ref index1, ref dataErr);
										if (!dataErr)
											msg1 += string.Format(" ErrorCode\t: 0x{0:X2} ({1:D})\n", num8, num8);
									}
								}
							}
							goto label_284;
						case 64770:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								ushort num6 = dataUtils.Unload16Bits(data, ref index1, ref dataErr, false);
								if (!dataErr)
									msg1 += string.Format(" ClientRxMTU\t: 0x{0:X4} ({1:D})\n", num6, num6);
							}
							goto label_284;
						case 64771:
							ushort num24 = dataUtils.Unload16Bits(data, ref index1, ref dataErr, false);
							if (!dataErr)
							{
								dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
								if (!dataErr)
									msg1 += string.Format(" ServerRxMTU\t: 0x{0:X4} ({1:D})\n", num24, num24);
							}
							goto label_284;
						case 64772:
							dspCmdUtils.AddConnectStartEndHandle(data, ref index1, ref dataErr, ref msg1);
							goto label_284;
						case 64773:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								byte num6 = dataUtils.Unload8Bits(data, ref index1, ref dataErr);
								if (!dataErr)
								{
									msg1 += string.Format(" Format\t\t: 0x{0:X2} ({1:S})\n", num6, devUtils.GetFindFormatStr(num6));
									int uuidLength = devUtils.GetUuidLength(num6, ref dataErr);
									if (!dataErr)
									{
										int dataLength = uuidLength + 2;
										int totalLength = (int)num1 + 4 - index1;
										msg1 += devUtils.UnloadHandleValueData(data, ref index1, totalLength, dataLength, ref dataErr);
									}
								}
							}
							goto label_284;
						case 64774:
							dspCmdUtils.AddConnectStartEndHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								str2 = string.Empty;
								msg1 += string.Format(" Type\t\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, 2, ref dataErr));
								if (!dataErr)
								{
									str2 = string.Empty;
									dspCmdUtils.AddValue(data, ref index1, ref dataErr, ref msg1, (int)num1, 4);
								}
							}
							goto label_284;
						case 64775:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
								msg1 += string.Format(" HandlesInfo\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, (int)num1 + 4 - index1, ref dataErr));
							goto label_284;
						case 64776:
							dspCmdUtils.AddConnectStartEndHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
								msg1 += string.Format(" Type\t\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, (int)num1 + 4 - index1, ref dataErr));
							goto label_284;
						case 64777:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								byte num6 = dataUtils.Unload8Bits(data, ref index1, ref dataErr);
								if (!dataErr)
								{
									msg1 += string.Format(" Length\t\t: 0x{0:X2} ({1:D})\n", num6, num6);
									if ((int)num6 != 0)
									{
										int totalLength = (int)num1 + 4 - index1;
										msg1 += devUtils.UnloadHandleValueData(data, ref index1, totalLength, (int)num6, ref dataErr);
									}
								}
							}
							goto label_284;
						case 64778:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
								dspCmdUtils.AddHandle(data, ref index1, ref dataErr, ref msg1);
							goto label_284;
						case 64779:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
								dspCmdUtils.AddValue(data, ref index1, ref dataErr, ref msg1, (int)num1, 4);
							goto label_284;
						case 64780:
							dspCmdUtils.AddConnectHandleOffset(data, ref index1, ref dataErr, ref msg1);
							goto label_284;
						case 64781:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
								dspCmdUtils.AddValue(data, ref index1, ref dataErr, ref msg1, (int)num1, 4);
							goto label_284;
						case 64782:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								for (int index2 = 0; index2 < ((int)num1 - 2) / 2; ++index2)
								{
									ushort num6 = dataUtils.Unload16Bits(data, ref index1, ref dataErr, false);
									if (!dataErr)
										msg1 += string.Format(" Handle #{0:D}\t: 0x{1:X4} ({1:D})\n", index2, num6, num6);
									else
										break;
								}
							}
							goto label_284;
						case 64783:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
								dspCmdUtils.AddValue(data, ref index1, ref dataErr, ref msg1, (int)num1, 4);
							goto label_284;
						case 64784:
							dspCmdUtils.AddConnectStartEndHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
								msg1 += string.Format(" GroupType\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, (int)num1 + 4 - index1, ref dataErr));
							goto label_284;
						case 64785:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								byte num6 = dataUtils.Unload8Bits(data, ref index1, ref dataErr);
								if (!dataErr)
								{
									msg1 += string.Format(" Length\t\t: 0x{0:X2} ({1:D})\n", num6, num6);
									msg1 += string.Format(" DataList\t\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, (int)num1 + 4 - index1, ref dataErr));
								}
							}
							goto label_284;
						case 64786:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								int num6 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
								if (!dataErr)
								{
									msg1 += string.Format(" Signature\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapYesNoStr(bits1));
									int num7 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
									if (!dataErr)
									{
										msg1 += string.Format(" Command\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapYesNoStr(bits1));
										int num8 = (int)dspCmdUtils.AddHandle(data, ref index1, ref dataErr, ref msg1);
										if (!dataErr)
											dspCmdUtils.AddValue(data, ref index1, ref dataErr, ref msg1, (int)num1, 4);
									}
								}
							}
							goto label_284;
						case 64787:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							goto label_284;
						case 64790:
						case 64791:
							dspCmdUtils.AddConnectHandleOffset(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
								dspCmdUtils.AddValue(data, ref index1, ref dataErr, ref msg1, (int)num1, 4);
							goto label_284;
						case 64792:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								int num6 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
								if (!dataErr)
									msg1 += string.Format(" Flags\t\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetAttExecuteWriteFlagsStr(bits1));
							}
							goto label_284;
						case 64793:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							goto label_284;
						case 64795:
						case 64797:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								int num6 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
								if (!dataErr)
								{
									msg1 += string.Format(" Authenticated\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapYesNoStr(bits1));
									int num7 = (int)dspCmdUtils.AddHandle(data, ref index1, ref dataErr, ref msg1);
									if (!dataErr)
										dspCmdUtils.AddValue(data, ref index1, ref dataErr, ref msg1, (int)num1, 4);
								}
							}
							goto label_284;
						case 64798:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							goto label_284;
					}
				}
			}
			else
			{
				if (num2 <= 64925U)
				{
					switch (num2)
					{
						case 64898:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								ushort num6 = dataUtils.Unload16Bits(data, ref index1, ref dataErr, false);
								if (!dataErr)
									msg1 += string.Format(" ClientRxMTU\t: 0x{0:X4} ({1:D})\n", num6, num6);
							}
							goto label_284;
						case 64900:
							dspCmdUtils.AddConnectStartEndHandle(data, ref index1, ref dataErr, ref msg1);
							goto label_284;
						case 64902:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
								dspCmdUtils.AddValue(data, ref index1, ref dataErr, ref msg1, (int)num1, 4);
							goto label_284;
						case 64904:
							dspCmdUtils.AddConnectStartEndHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
								msg1 += string.Format(" Type\t\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, (int)num1 + 4 - index1, ref dataErr));
							goto label_284;
						case 64906:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
								dspCmdUtils.AddHandle(data, ref index1, ref dataErr, ref msg1);
							goto label_284;
						case 64908:
							dspCmdUtils.AddConnectHandleOffset(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
								msg1 += string.Format(" Type\t\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, (int)num1 + 4 - index1, ref dataErr));
							goto label_284;
						case 64910:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
								msg1 += string.Format(" Handles\t\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, (int)num1 + 4 - index1, ref dataErr));
							goto label_284;
						case 64912:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							goto label_284;
						case 64914:
							break;
						case 64918:
							dspCmdUtils.AddConnectHandleOffset(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
								dspCmdUtils.AddValue(data, ref index1, ref dataErr, ref msg1, (int)num1, 4);
							goto label_284;
						case 64923:
						case 64925:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								msg1 += string.Format(" Authentic\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapYesNoStr(bits1));
								int num6 = (int)dspCmdUtils.AddHandle(data, ref index1, ref dataErr, ref msg1);
								if (!dataErr)
									dspCmdUtils.AddValue(data, ref index1, ref dataErr, ref msg1, (int)num1, 4);
							}
							goto label_284;
						default:
							goto label_280;
					}
				}
				else if (num2 <= 65041U)
				{
					switch (num2)
					{
						case 64944:
							dspCmdUtils.AddConnectStartEndHandle(data, ref index1, ref dataErr, ref msg1);
							goto label_284;
						case 64946:
							dspCmdUtils.AddConnectStartEndHandle(data, ref index1, ref dataErr, ref msg1);
							goto label_284;
						case 64948:
							dspCmdUtils.AddConnectStartEndHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
								msg1 += string.Format(" Type\t\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, (int)num1 + 4 - index1, ref dataErr));
							goto label_284;
						case 64950:
						case 64952:
							break;
						case 64954:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								byte num6 = dataUtils.Unload8Bits(data, ref index1, ref dataErr);
								if (!dataErr)
								{
									msg1 += string.Format(" Num Reqs\t: 0x{0:X2} ({1:D})\n", num6, num6);
									if ((int)num6 > 0)
									{
										for (int index2 = 0; index2 < (int)num6; ++index2)
										{
											byte num7 = dataUtils.Unload8Bits(data, ref index1, ref dataErr);
											if (!dataErr)
											{
												msg1 += string.Format(" Value Len\t: 0x{0:X2} ({1:D})\n", num7, num7);
												ushort num8 = dataUtils.Unload16Bits(data, ref index1, ref dataErr, false);
												if (!dataErr)
												{
													msg1 += string.Format(" Handle\t\t: 0x{0:X4} ({1:D})\n", num8, num8);
													ushort num9 = dataUtils.Unload16Bits(data, ref index1, ref dataErr, false);
													if (!dataErr)
													{
														msg1 += string.Format(" Offset\t\t: 0x{0:X4} ({1:D})\n", num9, num9);
														if ((int)num7 > 0)
														{
															msg1 += string.Format(" Value\t\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, (int)num7, ref dataErr));
															if (dataErr)
																break;
														}
													}
													else
														break;
												}
												else
													break;
											}
											else
												break;
										}
									}
								}
							}
							goto label_284;
						case 64956:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
								dspCmdUtils.AddHandle(data, ref index1, ref dataErr, ref msg1);
							goto label_284;
						case 64958:
							dspCmdUtils.AddConnectHandleOffset(data, ref index1, ref dataErr, ref msg1);
							goto label_284;
						case 64960:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								dspCmdUtils.AddOffset(data, ref index1, ref dataErr, ref msg1);
								if (!dataErr)
									dspCmdUtils.AddValue(data, ref index1, ref dataErr, ref msg1, (int)num1, 4);
							}
							goto label_284;
						case 64962:
							dspCmdUtils.AddConnectHandleOffset(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
								dspCmdUtils.AddValue(data, ref index1, ref dataErr, ref msg1, (int)num1, 4);
							goto label_284;
						case 65020:
							ushort num10 = dataUtils.Unload16Bits(data, ref index1, ref dataErr, false);
							if (!dataErr)
							{
								msg1 += string.Format(" UUID\t\t: 0x{0:X4} ({1:D})\n", num10, num10);
								ushort num6 = dataUtils.Unload16Bits(data, ref index1, ref dataErr, false);
								if (!dataErr)
									msg1 += string.Format(" NumAttrst\t: 0x{0:X4} ({1:D})\n", num6, num6);
							}
							goto label_284;
						case 65021:
							int num11 = (int)dspCmdUtils.AddHandle(data, ref index1, ref dataErr, ref msg1);
							goto label_284;
						case 65022:
							msg1 += string.Format(" UUID\t\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, (int)num1 + 4 - index1 - 1, ref dataErr));
							if (!dataErr)
							{
								int num6 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
								if (!dataErr)
									msg1 += string.Format(" Permissions\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGattPermissionsStr(bits1));
							}
							goto label_284;
						case 65024:
							int num25 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
							{
								msg1 += string.Format(" ProfileRole\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapProfileStr(bits1));
								byte num6 = dataUtils.Unload8Bits(data, ref index1, ref dataErr);
								if (!dataErr)
								{
									msg1 += string.Format(" MaxScanRsps\t: 0x{0:X2} ({1:D})\n", num6, num6) + string.Format(" IRK\t\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, 16, ref dataErr));
									if (!dataErr)
									{
										msg1 += string.Format(" CSRK\t\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, 16, ref dataErr));
										if (!dataErr)
										{
											uint num7 = dataUtils.Unload32Bits(data, ref index1, ref dataErr, false);
											if (!dataErr)
												msg1 += string.Format(" SignCounter\t: 0x{0:X8} ({1:D})\n", num7, num7);
										}
									}
								}
							}
							goto label_284;
						case 65027:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
								msg1 += string.Format(" AddrType\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapAddrTypeStr(bits1)) + string.Format(" Addr\t\t: 0x{0:S}\n", devUtils.UnloadDeviceAddr(data, ref addr, ref index1, true, ref dataErr));
							goto label_284;
						case 65028:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
							{
								msg1 += string.Format(" Mode\t\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapDiscoveryModeStr(bits1));
								int num6 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
								if (!dataErr)
								{
									msg1 += string.Format(" ActiveScan\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapEnableDisableStr(bits1));
									int num7 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
									if (!dataErr)
										msg1 += string.Format(" WhiteList\t\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapEnableDisableStr(bits1));
								}
							}
							goto label_284;
						case 65029:
						case 65032:
							goto label_284;
						case 65030:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
							{
								msg1 += string.Format(" EventType\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapEventTypeStr(bits1));
								int num6 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
								if (!dataErr)
								{
									msg1 += string.Format(" InitAddrType\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapAddrTypeStr(bits1)) + string.Format(" InitAddrs\t\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, 6, ref dataErr));
									if (!dataErr)
									{
										dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
										if (!dataErr)
										{
											msg1 += string.Format(" ChannelMap\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapChannelMapStr(bits1));
											dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
											if (!dataErr)
												msg1 += string.Format(" FilterPolicy\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapFilterPolicyStr(bits1));
										}
									}
								}
							}
							goto label_284;
						case 65031:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
							{
								msg1 += string.Format(" AdType\t\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapAdventAdTypeStr(bits1));
								dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
								if (!dataErr)
									msg1 += string.Format(" DataLength\t: 0x{0:X2} ({1:D})\n", bits1, bits1) + string.Format(" AdvertData\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, (int)num1 + 4 - index1, ref dataErr));
							}
							goto label_284;
						case 65033:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
							{
								msg1 += string.Format(" HighDutyCycle\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapEnableDisableStr(bits1));
								dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
								if (!dataErr)
								{
									msg1 += string.Format(" WhiteList\t\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapEnableDisableStr(bits1));
									dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
									if (!dataErr)
										msg1 += string.Format(" AddrTypePeer\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapAddrTypeStr(bits1)) + string.Format(" PeerAddr\t\t: {0:S}\n", devUtils.UnloadDeviceAddr(data, ref addr, ref index1, true, ref dataErr));
								}
							}
							goto label_284;
						case 65034:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								int num6 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
								if (!dataErr)
									msg1 += string.Format(" discReason\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapDisconnectReasonStr(bits1));
							}
							goto label_284;
						case 65035:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								int num6 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
								if (!dataErr)
								{
									msg1 += string.Format(" sec.ioCaps\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapIOCapsStr(bits1));
									dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
									if (!dataErr)
									{
										msg1 += string.Format(" sec.oobAvail\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapTrueFalseStr(bits1));
										msg1 += string.Format(" sec.oob\t\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, 16, ref dataErr));
										if (!dataErr)
										{
											dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
											if (!dataErr)
											{
												msg1 += string.Format(" sec.authReq\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapAuthReqStr(bits1));
												dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
												if (!dataErr)
												{
													msg1 += string.Format(" sec.maxEKeySize\t: 0x{0:X2} ({1:D})\n", bits1, bits1);
													int num31 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
													if (!dataErr)
													{
														msg1 += string.Format(" sec.keyDist\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapKeyDiskStr(bits1));
														dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
														if (!dataErr)
														{
															msg1 += string.Format(" pair.Enable\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapEnableDisableStr(bits1));
															dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
															if (!dataErr)
															{
																msg1 += string.Format(" pair.ioCaps\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapIOCapsStr(bits1));
																dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
																if (!dataErr)
																{
																	msg1 += string.Format(" pair.oobDFlag\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapEnableDisableStr(bits1));
																	dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
																	if (!dataErr)
																	{
																		msg1 += string.Format(" pair.authReq\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapAuthReqStr(bits1));
																		dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
																		if (!dataErr)
																		{
																			msg1 += string.Format(" pair.maxEKeySize\t: 0x{0:X2} ({1:D})\n", bits1, bits1);
																			int num37 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
																			if (!dataErr)
																				msg1 += string.Format(" pair.keyDist\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapKeyDiskStr(bits1));
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
							goto label_284;
						case 65036:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								string str3 = string.Empty;
								for (int index2 = 0; index2 < 6; ++index2)
								{
									str3 += string.Format("{0:X2} ", dataUtils.Unload8Bits(data, ref index1, ref dataErr));
									if (dataErr)
										break;
								}
								string msg3 = str3.Trim();
								msg1 += string.Format(" PassKey\t\t: {0:S}\n", devUtils.HexStr2UserDefinedStr(msg3, SharedAppObjs.StringType.ASCII));
							}
							goto label_284;
						case 65037:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
								if (!dataErr)
									msg1 += string.Format(" AuthReq\t\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapAuthReqStr(bits1));
							}
							goto label_284;
						case 65038:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
								if (!dataErr)
								{
									msg1 += string.Format(" Authenticated\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapAuthenticatedCsrkStr(bits1));
									msg1 += string.Format(" CSRK\t\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, 16, ref dataErr));
									if (!dataErr)
									{
										uint num7 = dataUtils.Unload32Bits(data, ref index1, ref dataErr, false);
										if (!dataErr)
											msg1 += string.Format(" SignCounter\t: 0x{0:X8} ({1:D})\n", num7, num7);
									}
								}
							}
							goto label_284;
						case 65039:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								int num6 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
								if (!dataErr)
								{
									msg1 += string.Format(" Authenticated\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapYesNoStr(bits1));
									msg1 += string.Format(" LongTermKey\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, 16, ref dataErr));
									if (!dataErr)
									{
										ushort num7 = dataUtils.Unload16Bits(data, ref index1, ref dataErr, false);
										if (!dataErr)
										{
											msg1 += string.Format(" DIV\t\t: 0x{0:X4} ({1:D})\n", num7, num7);
											msg1 += string.Format(" Rand\t\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, 8, ref dataErr));
											if (!dataErr)
											{
												int num8 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
												if (!dataErr)
													msg1 += string.Format(" LTKSize\t\t: 0x{0:X2} ({1:D})\n", bits1, bits1);
											}
										}
									}
								}
							}
							goto label_284;
						case 65040:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								int num6 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
								if (!dataErr)
									msg1 += string.Format(" Reason\t\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapSMPFailureTypesStr(bits1));
							}
							goto label_284;
						case 65041:
							dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
							if (!dataErr)
							{
								dataUtils.Unload16Bits(data, ref index1, ref bits2, ref dataErr, false);
								if (!dataErr)
								{
									msg1 += string.Format(" IntervalMin\t: 0x{0:X4} ({1:D})\n", bits2, bits2);
									dataUtils.Unload16Bits(data, ref index1, ref bits2, ref dataErr, false);
									if (!dataErr)
									{
										msg1 += string.Format(" IntervalMax\t: 0x{0:X4} ({1:D})\n", bits2, bits2);
										dataUtils.Unload16Bits(data, ref index1, ref bits2, ref dataErr, false);
										if (!dataErr)
										{
											msg1 += string.Format(" ConnLatency\t: 0x{0:X4} ({1:D})\n", bits2, bits2);
											dataUtils.Unload16Bits(data, ref index1, ref bits2, ref dataErr, false);
											if (!dataErr)
												msg1 += string.Format(" ConnTimeout\t: 0x{0:X4} ({1:D})\n", bits2, bits2);
										}
									}
								}
							}
							goto label_284;
						default:
							goto label_280;
					}
				}
				else
				{
					switch (num2)
					{
						case 65072:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
							{
								msg1 += string.Format(" ParamID\t\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapParamIdStr(bits1));
								int num6 = (int)dataUtils.Unload16Bits(data, ref index1, ref bits2, ref dataErr, false);
								if (!dataErr)
									msg1 += string.Format(" ParamValue\t: 0x{0:X4} ({1:D})\n", bits2, bits2);
							}
							goto label_284;
						case 65073:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
								msg1 += string.Format(" ParamID\t\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapParamIdStr(bits1));
							goto label_284;
						case 65074:
							msg1 += string.Format(" IRK\t\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, 16, ref dataErr));
							if (!dataErr)
								msg1 += string.Format(" Addr\t\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, (int)num1 + 4 - index1, ref dataErr));
								goto label_284;
						case 65075:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
							{
								msg1 += string.Format(" AdType\t\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapAdTypesStr(bits1));
								dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
								if (!dataErr)
									msg1 += string.Format(" AdvDataLen\t: 0x{0:X2} ({1:D})\n", bits1, bits1) + string.Format(" AdvData\t\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, (int)num1 + 4 - index1, ref dataErr));
							}
							goto label_284;
						case 65076:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
								msg1 += string.Format(" AdType\t\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetGapAdTypesStr(bits1));
							goto label_284;
						case 65077:
						case 65155:
							goto label_284;
						case 65078:
							dataUtils.Unload16Bits(data, ref index1, ref bits2, ref dataErr, false);
							if (!dataErr)
							{
								msg1 += string.Format(" ParamID\t\t: 0x{0:X4} ({1:S})\n", bits2, devUtils.GetGapBondParamIdStr(bits2));
								int num6 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
								if (!dataErr)
								{
									msg1 += string.Format(" ParamLength\t: 0x{0:X2} ({1:D})\n", bits1, bits1);
									dspCmdUtils.AddValue(data, ref index1, ref dataErr, ref msg1, (int)num1, 4);
								}
							}
							goto label_284;
						case 65079:
							dataUtils.Unload16Bits(data, ref index1, ref bits2, ref dataErr, false);
							if (!dataErr)
								msg1 += string.Format(" ParamID\t\t: 0x{0:X4} ({1:S})\n", bits2, devUtils.GetGapBondParamIdStr(bits2));
							goto label_284;
						case 65152:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
								msg1 += string.Format(" ResetType\t: 0x{0:X2} ({1:S})\n", bits1, devUtils.GetUtilResetTypeStr(bits1));
							goto label_284;
						case 65153:
							dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
							{
								msg1 += string.Format(" NvID\t\t: 0x{0:X2} ({1:D})\n", bits1, bits1);
								dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
								if (!dataErr)
									msg1 += string.Format(" NvDataLen\t: 0x{0:X2} ({1:D})\n", bits1, bits1);
							}
							goto label_284;
						case 65154:
							int num46 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
							if (!dataErr)
							{
								msg1 += string.Format(" NvID\t\t: 0x{0:X2} ({1:D})\n", bits1, bits1);
								int num6 = (int)dataUtils.Unload8Bits(data, ref index1, ref bits1, ref dataErr);
								if (!dataErr)
									msg1 += string.Format(" NvDataLen\t: 0x{0:X2} ({1:D})\n", bits1, bits1) + string.Format(" NvData\t\t: {0:S}\n", devUtils.UnloadColonData(data, ref index1, (int)num1 + 4 - index1, ref dataErr));
							}
							goto label_284;
						default:
							goto label_280;
					}
				}
				dspCmdUtils.AddConnectHandle(data, ref index1, ref dataErr, ref msg1);
				if (!dataErr)
				{
					dspCmdUtils.AddHandle(data, ref index1, ref dataErr, ref msg1);
					if (!dataErr)
						dspCmdUtils.AddValue(data, ref index1, ref dataErr, ref msg1, (int)num1, 4);
				}
				goto label_284;
			}

		label_280:
			for (int index2 = 4; index2 < (int)num1 + 4 && index2 < data.Length; ++index2)
			{
				msg2 = msg2 + string.Format("{0:X2} ", data[index2]);
				devUtils.CheckLineLength(ref msg2, (uint)(index2 - 4), true);
			}
			msg1 += string.Format(" Raw\t\t: {0:S}\n", msg2);
			goto label_284;

		label_284:
			if (DisplayMsgCallback == null)
				return;
			if (dataErr)
				DisplayMsgCallback(SharedAppObjs.MsgType.Error, "Could Not Convert All The Data In The Following Message\n(Message Is Missing Data Bytes To Process)\n");
			if (data.Length != index1)
				DisplayMsgCallback(SharedAppObjs.MsgType.Warning, string.Format("The Last {0} Bytes In This Message Were Not Decoded.\n", (data.Length - index1)) + "(Message Has More Than The Expected Number Of Data Bytes)\n");
			if (DisplayMsgTimeCallback != null)
				DisplayMsgTimeCallback(SharedAppObjs.MsgType.Outgoing, msg1, txDataOut.time);
			if (!displayBytes)
				return;
			string msg4 = "";
			uint num47 = 0U;
			foreach (byte num6 in data)
			{
				msg4 = msg4 + string.Format("{0:X2} ", num6);
				devUtils.CheckLineLength(ref msg4, num47++, false);
			}
			DisplayMsgCallback(SharedAppObjs.MsgType.TxDump, msg4);
		}
	}
}
