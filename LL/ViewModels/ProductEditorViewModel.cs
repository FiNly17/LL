using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using LL.Infrastructure;
using LL.Infrastructure.Commands;
using LL.Models;
using LL.Services;
using LL.Views;

using Microsoft.Win32;

namespace LL.ViewModels
{
	public class ProductEditorViewModel : ViewModel
	{
		public static Product InitialProduct { get; set; }

		public bool IsEditing { get; }

		public string State { get => IsEditing ? "Редактирование товара" : "Добавление товара"; }

		public List<ProductTypes> ProductTypes => Enum.GetValues(typeof(ProductTypes)).Cast<ProductTypes>().ToList();

		public List<ClothingSizes> ClothingSizes => Enum.GetValues(typeof(ClothingSizes)).Cast<ClothingSizes>().ToList();

		public int Id { get; }

		private string _model = string.Empty;

		public string Model
		{
			get { return _model; }
			set { SetProperty(ref _model, value); }
		}

		private string _brand = string.Empty;

		public string Brand
		{
			get { return _brand; }
			set { SetProperty(ref _brand, value); }
		}

		private ProductTypes _productType;

		public ProductTypes ProductType
		{
			get { return _productType; }
			set { SetProperty(ref _productType, value); }
		}

		private string _price = string.Empty;

		public string Price
		{
			get { return _price; }
			set { SetProperty(ref _price, value); }
		}

		private byte[] _image;

		public byte[] Image
		{
			get { return _image; }
			set { SetProperty(ref _image, value); }
		}

		private double _shoesSize;

		public double ShoesSize
		{
			get { return _shoesSize; }
			set { SetProperty(ref _shoesSize, value); }
		}

		private ClothingSizes _clothingSize;

		public ClothingSizes ClothingSize
		{
			get { return _clothingSize; }
			set { SetProperty(ref _clothingSize, value); }
		}

		public string Error { get; private set; }

		//public string this[string columnName] => Validate(columnName);

		public ICommand SaveCommand { get; set; }

		private static bool CanSaveCommandExecute(object p) => true;

		private void OnSaveCommandExecuted(object p) => Save();

		public ICommand LoadImgCommand { get; set; }

		private static bool CanLoadImgCommandExecute(object p) => true;

		private void OnLoadImgCommandExecuted(object p) => LoadImg();

		public ProductEditorViewModel()
		{
			SaveCommand = new RelayCommand(OnSaveCommandExecuted, CanSaveCommandExecute);
			LoadImgCommand = new RelayCommand(OnLoadImgCommandExecuted, CanLoadImgCommandExecute);

			if (InitialProduct != null)
			{
				Id = InitialProduct.Id;
				Model = InitialProduct.Model;
				Brand = InitialProduct.Brand;
				ProductType = InitialProduct.Type;
				Price = InitialProduct.Price.ToString();
				Image = InitialProduct.Image;

				InitialProduct = null;
			}
			else
			{
				Image = ImageProvider.GetDefault();
			}
		}

		private void Save()
		{
			//string errors = CheckFields();
			//if (!string.IsNullOrWhiteSpace(errors))
			//{
			//	MessageBox.Show(errors, "Ошибка ввода данных");
			//	return;
			//}

			try
			{
				if (IsEditing)
				{
					var product = DataContext.GetInstance().Products.Find(Id);
					product.Model = Model;
					product.Brand = Brand;
					product.Type = ProductType;
					product.Price = Convert.ToDouble(Price);
					product.Image = Image;

					DataContext.GetInstance().SaveChanges();
				}
				else
				{
					if (ProductType == Models.ProductTypes.Clothing)
						DataContext.GetInstance().Products.Add(new Clothing(
							ClothingSize, Model, Brand,
							Convert.ToDouble(Price), Image));
					else
						DataContext.GetInstance().Products.Add(new Shoes(
							ShoesSize, Model, Brand,
							Convert.ToDouble(Price), Image));
				}

				DataContext.GetInstance().SaveChanges();

				MessageBox.Show("Сохранено");
				new SwitchAdminPageCommand().Execute(AdminPages.Products);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Не удалось сохранить изменения");
				Logger.Log(ex);
			}
		}

		//private string CheckFields()
		//{
		//	string errors = string.Empty;

		//	errors += Validate("Title") + "\n";
		//	errors += Validate("Author") + "\n";
		//	errors += Validate("Genre") + "\n";
		//	errors += Validate("Amt") + "\n";

		//	return errors.Trim();
		//}

		//private string Validate(string columnName)
		//{
		//	if (columnName == null)
		//		return string.Empty;

		//	string error = string.Empty;

		//	switch (columnName)
		//	{
		//		case "Title":
		//			{
		//				if (string.IsNullOrEmpty(Title))
		//					return "Введите название книги";

		//				var (isValid, forbiddenSymbols) = Validator.Validate(Title, Validator.BookTitleRegex);

		//				if (!isValid)
		//					error = $"Введены недопустимые символы: {Validator.JoinSymbols(forbiddenSymbols)}";
		//			}
		//			break;

		//		case "Author":
		//			{
		//				if (string.IsNullOrEmpty(Author))
		//					return "Введите автора";

		//				var (isValid, forbiddenSymbols) = Validator.Validate(Author, Validator.BookAuthorRegex);

		//				if (!isValid)
		//					error = $"Введены недопустимые символы: {Validator.JoinSymbols(forbiddenSymbols)}";
		//				break;
		//			}
		//		case "Genre":
		//			{
		//				if (string.IsNullOrEmpty(Genre))
		//					return string.Empty;

		//				var (isValid, forbiddenSymbols) = Validator.Validate(Genre, Validator.BookGenreRegex);

		//				if (!isValid)
		//					error = $"Введены недопустимые символы: {Validator.JoinSymbols(forbiddenSymbols)}";
		//				break;
		//			}
		//		case "Amt":
		//			if (!int.TryParse(Amt, out int value))
		//				error = "Введите число";
		//			else if (value < 0)
		//				error = "Количество книг должно быть положительным числом";
		//			break;
		//	}

		//	Error = error;
		//	return error;
		//}

		private void LoadImg()
		{
			var dialog = new OpenFileDialog()
			{
				Filter = "Картинки| *.png;*.jpg;*.jpeg;*.bmp"
			};

			if (dialog.ShowDialog() == true)
			{
				Image = ImageProvider.ImageToByte(dialog.FileName);
			}
		}
	}
}