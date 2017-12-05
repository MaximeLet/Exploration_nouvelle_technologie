using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TP2.Core.Validations;
using TP2.Core.Helpers;
using Tp2.Externalization;

namespace TP2.Core.ViewModels
{
	public class QrCodeCreatorPageViewModel : BindableBase
	{
		private readonly INavigationService _navigationService;
		private ValidatableObject<string> _model;
		private ValidatableObject<string> _serialNumber;
		private string _radioId;
		
		public ICommand ValidateModelCommand => new DelegateCommand(ValidateModel);
		public ICommand ValidateSerialNumberCommand => new DelegateCommand(ValidateSerialNumber);
		public ICommand NavigateToDisplayNewQrCodeCommand => new DelegateCommand(NavigateToDisplayNewQrCode, canExecuteMethod:CanExecuteNavigateToDisplayNewQrCode);

		public QrCodeCreatorPageViewModel(INavigationService navigationService)
        {
	        _navigationService = navigationService;
	        
	        _model = new ValidatableObject<string>();
	        AddModelValidations();
	        
	        _serialNumber = new ValidatableObject<string>();
	        AddSerialNumberValidations();

	        _radioId = "";
        }
		
		private bool CanExecuteNavigateToDisplayNewQrCode()
		{
			if (Model.Value == null || SerialNumber.Value == null)
			{
				return false;
			}
			if (RadioId.Length == 0)
			{
				SetRadioId();
			}
			return Model.IsValid && SerialNumber.IsValid;
		}

		private void SetRadioId()
		{
			RadioId = UiText.RadioIdMessages.MsgIfNoRadioId;
		}

		private void NavigateToDisplayNewQrCode()
		{
			var parameters = new NavigationParameters
			{
				{
					"model",Model.Value
				},
				{
					"serialNumber", SerialNumber.Value
				},
				{
					"radioId", RadioId
				}
			};
			_navigationService.NavigateAsync(NavigationPaths.PathToGoDisplayNewQrCodePage, parameters);
		}

		private void ValidateSerialNumber()
		{
			_serialNumber.Validate();
		}
		
		private void ValidateModel()
		{
			_model.Validate();
		}

		private void AddModelValidations()
		{
			 _model.Validations.Add(new ModelValidation<string>());
		}
		
		private void AddSerialNumberValidations()
		{
			_serialNumber.Validations.Add(new SerialNumberValidation<string>());
		}

		public ValidatableObject<string> Model
		{
			get => _model;
			set => SetProperty(ref _model, value);
		}
		
		public ValidatableObject<string> SerialNumber
		{
			get => _serialNumber;
			set => SetProperty(ref _serialNumber, value);
		}

		public string RadioId
		{
			get => _radioId;
			set => SetProperty(ref _radioId, value);
		}
	}
}
