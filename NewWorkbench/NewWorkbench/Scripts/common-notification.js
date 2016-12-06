var $toastlast;

toastr.options = {
    closeButton: true,
    debug: true,
    progressBar: false,
    positionClass: 'toast-top-center',
    onclick: null
};

function ShowSuccess(title,message)
{
	toastr.success(message,title)
}

function ShowInfo(message, title)
{
    toastr.info(message, title)
}

function ShowWarning(title,message)
{
    toastr.warning(message, title)
}

function ShowError(title,message)
{
    toastr.error(message, title)
}
