using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DemoApplication.ViewModels
{
	public abstract class ViewModelBase : ObservableObject
    {
        public IDictionary<string, object> PreLoadNavigationParameters;

        public ViewModelBase()
        {

        }

        public virtual Task OnNavigatingTo(object? parameter)
        {
            PreLoadNavigationParameters = (IDictionary<string, object>)parameter;
            return Task.CompletedTask;
        }

        public virtual Task OnNavigatedFrom(bool isForwardNavigation)
                => Task.CompletedTask;

        public Task OnViewAppearing()
        {
            return OnPageAppearing();
        }

        public Task OnViewDisAppearing()
        {
            return OnPageDisAppearing();
        }

        public async virtual Task OnPageAppearing()
        {
            await this.LoadDataWhenAppearingTo();
        }

        public async virtual Task OnPageDisAppearing()
        {
           await this.LoadDataWhenDisAppearingTo();
        }

        protected virtual Task LoadDataWhenDisAppearingTo()
        {
            return Task.CompletedTask;
        }

        protected virtual Task LoadDataWhenAppearingTo()
        {
            return Task.CompletedTask;
        }

        public async virtual Task OnNavigatedTo()
        {
           await this.LoadDataWhenNavigatingTo(PreLoadNavigationParameters);
        }

        public virtual Task LoadDataWhenNavigatingTo(IDictionary<string, object> parameters)
        {
            return Task.CompletedTask;
        }

        public virtual void Destroy()
        {
            this.PreLoadNavigationParameters = null;
        }
    }
}

