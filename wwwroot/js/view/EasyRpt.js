var _me = {

    init: function () {        
        //datatable config
        var config = {
            dom: _crud.dtDom,
            columns: [
                { data: 'Name' },
                { data: 'Status' },
                { data: 'TplFile' },
                { data: '_Fun' },
                { data: '_Curd' },
            ],
            columnDefs: [
                _crud.dtColConfig,
				{ targets: [1], render: function (data, type, full, meta) {
                    return _crud.dtStatusName(data);
                }},
				{ targets: [3], render: function (data, type, full, meta) {
                    var html = '<a href="javascript:_me.onEmail(\'{0}\')">{1}</a>';
                    return _str.format(html, full.Id, "寄測試信");
                }},
				{ targets: [4], render: function (data, type, full, meta) {
                    return _crud.dtCrudFun(full.Id, full.Name, true, true, true);
                }},
            ],
        };

        //initial
        _crud.init(config);
    },

}; //class