using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
	public class ProductEditorViewModel : ViewModel, IDataErrorInfo
	{
		public static Product InitialProduct { get; set; }

		public bool IsEditing { get; }

		public string State { get => IsEditing ? "Редактирование товара" : "Добавление товара"; }

		public List<ProductTypes> ProductTypesList => Enum.GetValues(typeof(ProductTypes))
			.Cast<ProductTypes>().Where(type => type != ProductTypes.None).ToList();

		public List<ClothingSizes> ClothingSizesList => Enum.GetValues(typeof(ClothingSizes))
			.Cast<ClothingSizes>().Where(type => type != ClothingSizes.None).ToList();

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

		private ProductTypes _type = ProductTypes.None;

		public ProductTypes Type
		{
			get { return _type; }
			set { SetProperty(ref _type, value); }
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

		public string Error => throw new NotImplementedException();

		public string this[string columnName] => Validate(columnName);

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
				IsEditing = true;

				Id = InitialProduct.Id;
				Model = InitialProduct.Model;
				Brand = InitialProduct.Brand;
				Type = InitialProduct.Type;
				Price = InitialProduct.Price.ToString();
				Image = InitialProduct.Image;

				InitialProduct = null;
			}
			else
			{
				IsEditing = false;
				Image = ImageProvider.GetDefault();
			}
		}

		private void Save()
		{
			string errors = CheckFields();
			if (!string.IsNullOrWhiteSpace(errors))
			{
				MessageBox.Show(errors, "Ошибка ввода данных");
				return;
			}

			try
			{
				if (IsEditing)
				{
					var product = DataContext.GetInstance().Products.Find(Id);
					product.Model = Model;
					product.Brand = Brand;
					product.Type = Type;
					product.Price = Convert.ToDouble(Price.Replace('.', ','));
					product.Image = Image;

					DataContext.GetInstance().SaveChanges();
				}
				else
				{
					if (Type == Models.ProductTypes.Clothing)
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

		private string CheckFields()
		{
			string errors = string.Empty;

			errors += Validate("Model") + "\n";
			errors += Validate("Brand") + "\n";
			errors += Validate("Price") + "\n";
			errors += Validate("Type") + "\n";
			if (Type == ProductTypes.None)
			{
				errors += "Укажите тип товара";
				return errors;
			}
			if (Type == ProductTypes.Clothing)
				errors += Validate("ClothingSize");
			else
				errors += Validate("ShoesSize");

			return errors.Trim();
		}

		private string Validate(string columnName)
		{
			if (columnName == null)
				return string.Empty;

			switch (columnName)
			{
				case "Model":
					{
						if (string.IsNullOrEmpty(Model))
							return "Введите название модели";
					}
					break;

				case "Brand":
					{
						if (string.IsNullOrEmpty(Brand))
							return "Введите название брэнда";
					}
					break;

				case "Price":
					{
						if (string.IsNullOrEmpty(Price))
							return "Введите центу товара";

						var value = Converter.StringToDouble(Price);
						if (value == null)
							return "Цена товара должна быть числом";

						if (value < 0)
							return "Цена товара должна быть положительным числом";
					}
					break;

				case "ShoesSize":
					{
						if (ShoesSize == 0)
							return "Введите размер обуви";

						if (ShoesSize < 0)
							return "Размер обуви должен быть положительным числом";
					}
					break;

				case "ClothingSize":
					{
						if (ClothingSize == ClothingSizes.None)
							return "Укажите размер одежды";
					}
					break;
			}

			return string.Empty;
		}

		private void LoadImg()
		{
			var dialog = new OpenFileDialog()
			{
				Filter = "Картинки| *;*;*;*.bmp"
			};

			if (dialog.ShowDialog() == true)
			{
				var (status, result) = ImageProvider.ImageToByte(dialog.FileName);
				if (status)
					Image = result;
				else
					MessageBox.Show("Не удалось загрузить изображение");
			}
		}
	}
}