using System;
using adme360.view;
using adme360.models.DTOs.Containers;

namespace adme360.view.Controls.Containers
{
    public interface IContainerImageView : IView
    {
        string PctContainerImagePathValue { set; }
        string SelectedContainerImageNameImageView { get; set; }
    }
}