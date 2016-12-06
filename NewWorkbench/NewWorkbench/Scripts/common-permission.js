//Process Permission

function ValidatePermission(v) {
    var permissionList = v;
    
    if(permissionList != '' && permissionList != undefined)
    {
        var permission = '';

        //循环连接权限列表
        $.each(permissionList, function (e, t) {
            permission += t.PERVALUE + ',';
        });

        //变成小写
        permission = permission.toLowerCase();

        $('.ibox a[action]').each(function () {
            //获取按钮属性
            var action = $(this).attr('action');

            //如不存在该权限，则删除该按钮(功能按钮)
            if(permission.indexOf(action.toLowerCase()) < 0)
            {
                $(this).remove();
            }

            //
            $('.ibox a[listaction]').each(function () {
                var listaction = $(this).attr('listaction');

                if(permission.indexOf(listaction.toLowerCase() +',') < 0 )
                {
                    $(this).remove();
                }
            });
        });
    }
}