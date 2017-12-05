using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TP2.Core.Repositories;
using TP2.Core.Repositories.Entities;

namespace TP2.Core.ViewModels
{
	public class InventoryPageViewModel : BindableBase
	{
        private readonly IRepository<Product> _productForInventoryRepository;
        private ObservableCollection<Product> _productsItems;
        public ObservableCollection<Product> Products
        {
            get { return _productsItems; }
            set { SetProperty(ref _productsItems, value);
            }
        }

        public InventoryPageViewModel(IRepository<Product> productForInventoryRepository)
        {
            _productForInventoryRepository = productForInventoryRepository;
            Products = _productForInventoryRepository.GetAllInventoryProduct();
        }

        public ICommand DeleteProductFromInventoryCommand => new DelegateCommand(DeleteProductFromInventory);

        private void DeleteProductFromInventory()
        {
            
        }

    }
}
