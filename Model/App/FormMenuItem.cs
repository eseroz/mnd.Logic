using System;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.App
{
    public class FormMenuItem : MyBindableBase
    {
        private decimal menuId;

        [Key]
        public decimal MenuId
        {
            get => menuId;
            set => SetProperty(ref menuId, value);
        }

        private decimal? parentMenuId;

        public Decimal? ParentMenuId
        {
            get => parentMenuId;
            set => SetProperty(ref parentMenuId, value);
        }

        private string formAd;

        public string FormAd
        {
            get => formAd;
            set => SetProperty(ref formAd, value);
        }

        private string yetkiliRoller;

        public string YetkiliRoller
        {
            get => yetkiliRoller;
            set => SetProperty(ref yetkiliRoller, value);
        }

        private string vm_Name;

        public string VM_Name
        {
            get => vm_Name;
            set => SetProperty(ref vm_Name, value);
        }

        private string vm_ParamObj;

        public string VM_ParamObj
        {
            get => vm_ParamObj;
            set => SetProperty(ref vm_ParamObj, value);
        }

        private string viewName;

        public string ViewName
        {
            get => viewName;
            set => SetProperty(ref viewName, value);
        }

        private string iconPath;

        public string IconPath
        {
            get => iconPath;
            set => SetProperty(ref iconPath, value);
        }

        private int? badgeValue;

        public int? BadgeValue
        {
            get => badgeValue;
            set => SetProperty(ref badgeValue, value);
        }

        private bool? isBadge;

        public bool? IsBadge
        {
            get => isBadge;
            set => SetProperty(ref isBadge, value);
        }


        private bool? visibility;

        public bool? Visibility
        {
            get => visibility;
            set => SetProperty(ref visibility, value);
        }
    }
}