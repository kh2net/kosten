using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using kosten.Extensions;
using kosten.Models;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace kosten.ViewModels.ResourcesViewModel
{
    public class CategoryEditViewModel : BaseViewModel
    {   
        
        
        readonly static string POPUP_NO_MORE_CATEGORY = "There are no more available Category";
        readonly static string POPUP_DELETE_CATEGORY = "Are you sure you want to remove this Category?";
        
        
        
        #region Attributes and Properties

        public bool Editing = true;

        Category _category;
        public Category Category
        {
            get { return _category; }
            set { SetValue(ref _category, value); }
        }
        
        
        // this collection is used to store all Category
        ObservableCollection<Category> _categoryAllList;

        // this collection is used as ItemSource for the Parent ListView 
        ObservableCollection<Category> _parentList;

        public ObservableCollection<Category> ParentList
        {
            get { return _parentList; }
            set { SetValue(ref _parentList, value); }
        }
        
        #endregion

        
        
        public ICommand CategoryPickerCommand => new Command(async () => await PickCategoryFromList());
        public ICommand CategoryPickedFromListCommand => new Command<Category>(async (obj) => await RemoveCategoryFromList(obj));
        
        

        public CategoryEditViewModel(Category categoryToEdit)
        {
            if (categoryToEdit == null)
            {
                categoryToEdit = new Category();
                Editing = false;
            }

            Category = categoryToEdit;
            
        }
        
        public async Task SaveOrEditCategory()
        {
            OnLoadingStarted(EventArgs.Empty);
            
            Category.Parent = ParentList.ToDictionary((arg) => arg.Id).Keys.ToArray();
            
            if (Editing)
                await App.CategoryService.PUT(_category);
            else
                await App.CategoryService.POST(_category);

            OnLoadingEnded(EventArgs.Empty);
        }
        
        async Task PickCategoryFromList()
        {
            if (_parentList.Count != _categoryAllList.Count)
            {
                // get available Category
                var availableCategoryList = _categoryAllList.Except(_parentList);

                PickerPopUp popUp = new PickerPopUp(availableCategoryList);
                popUp.ItemSelectedEvent += (sender, e) =>
                {
                    // add the category to the ParentList
                    ParentList.Add(sender as Category);
                };

                await PopupNavigation.Instance.PushAsync(popUp);
            }
            else
            {
                CustomAlertPopUp popUp = new CustomAlertPopUp(POPUP_NO_MORE_CATEGORY);
                await PopupNavigation.Instance.PushAsync(popUp);
            }
        }
        
        
        async Task RemoveCategoryFromList(Category category)
        {
            CustomAlertPopUp popUp = new CustomAlertPopUp(POPUP_DELETE_CATEGORY);
            popUp.ButtonClickedEvent += (sender, e) =>
            {
                // remove the Category from the ParentList
                ParentList.Remove(category);

                // move the Category in the _categoryAllList
                _categoryAllList.Add(category);
            };

            await PopupNavigation.Instance.PushAsync(popUp);
        }
        
    }
}