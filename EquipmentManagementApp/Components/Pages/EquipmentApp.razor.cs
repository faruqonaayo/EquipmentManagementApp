using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipmentManagementApp.Components.Data;

namespace EquipmentManagementApp.Components.Pages
{
    public partial class EquipmentApp
    {
        
        int editEquipmentId = 0;
        public string equipmentNameInput = "";
        public string equipmentCategoryInput = "";
        public string equipmentDescriptionInput = "";
        public string equipmentDailyRentalCostInput = "";
        public string successMessage = "";
        public string errorMessage = "";
        private readonly EquipmentDbService _equipmentDbService =  new EquipmentDbService();

        List<Equipment> equipmentList = new List<Equipment>();
        //Populate List
        protected override async Task OnInitializedAsync()
        {
            equipmentList = await _equipmentDbService.GetEquipment();
        }

        public async Task saveButton_Clicked()
        {
            try
            {
                if (equipmentNameInput != "" && equipmentCategoryInput != "" && equipmentDescriptionInput != "" && equipmentDailyRentalCostInput != "")
                {
                    if (editEquipmentId == 0)
                    {
                        await _equipmentDbService.CreateEquipment(new Equipment
                        {
                            Name = equipmentNameInput,
                            Category = equipmentCategoryInput,
                            Description = equipmentDescriptionInput,
                            DailyRentalCost = equipmentDailyRentalCostInput
                        });
                    }
                    else
                    {
                        await _equipmentDbService.UpdateEquipment(new Equipment
                        {
                            Id = editEquipmentId,
                            Name = equipmentNameInput,
                            Category = equipmentCategoryInput,
                            Description = equipmentDescriptionInput,
                            DailyRentalCost = equipmentDailyRentalCostInput
                        });

                        editEquipmentId = 0;
                    }
                    equipmentNameInput = "";
                    equipmentCategoryInput = "";
                    equipmentDescriptionInput = "";
                    equipmentDailyRentalCostInput = "";
                    successMessage = "Added Sucessfully";
                    errorMessage = "";
                    await OnInitializedAsync();
                }
                else
                {
                    errorMessage = "Field cannot be blanck";
                    successMessage = "";
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

        }

        public async Task deleteButtontn_clicked(Equipment currentEquipment)
        {
            await _equipmentDbService.DeleteEquipment(currentEquipment);
            await OnInitializedAsync();
        }

        public async Task editButton_clicked(Equipment currentEquipment)
        {
            editEquipmentId = currentEquipment.Id;
            equipmentNameInput = currentEquipment.Name;
            equipmentCategoryInput = currentEquipment.Category;
            equipmentDescriptionInput = currentEquipment.Description;
            equipmentDailyRentalCostInput = currentEquipment.DailyRentalCost;

            
            ToggleClass();
            await OnInitializedAsync();
        }

        bool applyNewClass = false;

        void ToggleClass()
        {
            applyNewClass = !applyNewClass;
        }
    }
}
