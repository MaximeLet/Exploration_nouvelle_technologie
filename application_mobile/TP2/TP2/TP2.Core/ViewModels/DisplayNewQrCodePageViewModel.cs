using Prism.Mvvm;
using System;
using Prism.Navigation;
using TP2.Core.Services;

namespace TP2.Core.ViewModels
{
	public class DisplayNewQrCodePageViewModel : BindableBase, INavigatedAware
	{
		private string _model;
		private string _serialNumber;
		private string _radioId;
		private DateTime _date;
		private readonly IQrCodeService _qrCodeService;
		private string _newQrCodePath;
		
        public DisplayNewQrCodePageViewModel(IQrCodeService qrCodeService)
        {
	        _qrCodeService = qrCodeService;

	        SetCurrentDate();
        }

		private void SetCurrentDate()
		{
			Date = DateTime.Now;
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
		}

		public async void OnNavigatedTo(NavigationParameters parameters)
		{
			Model = (string) parameters["model"];
			SerialNumber = (string) parameters["serialNumber"];
			RadioId = (string) parameters["radioId"];
			var path = await _qrCodeService.GetQrCode(_model, _serialNumber, _radioId, _date);
			NewQrCodePath = path;
		}

		public string NewQrCodePath
		{
			get => _newQrCodePath;
			set => SetProperty(ref _newQrCodePath, value);
		}

		public string Model
		{
			get => _model;
			set => SetProperty(ref _model, value);
		}
		
		public string SerialNumber
		{
			get => _serialNumber;
			set => SetProperty(ref _serialNumber, value);
		}
		
		public DateTime Date
		{
			get => _date;
			set => SetProperty(ref _date, value);
		}
		
		public string RadioId
		{
			get => _radioId;
			set => SetProperty(ref _radioId, value);
		}
		
	}
}
