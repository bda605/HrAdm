var _me = {

    init: function () {        
        //datatable config
        var config = {
            dom: _crud.dtDom,
            columns: [
                { data: 'UserName' },
                //{ data: 'AgentName' },
                { data: 'LeaveName' },
                { data: 'StartTime' },
                { data: 'EndTime' },
                { data: 'Hours' },
                { data: 'NodeName' },
                { data: 'Created' },
                { data: '_Fun' },
            ],
            columnDefs: [
                _crud.dtColConfig,
				{ targets: [2], render: function (data, type, full, meta) {
                    return _date.jsToUiDt2(data);
                }},
				{ targets: [3], render: function (data, type, full, meta) {
                    return _date.jsToUiDt2(data);
                }},
				{ targets: [6], render: function (data, type, full, meta) {
                    return _date.jsToUiDt(data);
                }},
				{ targets: [7], render: function (data, type, full, meta) {
                    return _str.format('<button type="button" class="btn btn-outline-secondary btn-sm" onclick="_crud.onUpdate(\'{0}\')">審核</button>', full.Id);
                }},
            ],
        };

        //initial
        //_me.edit0 = new EditOne();
        //_me.edit0.fnAfterOpenEdit = _me.edit0_afterOpenEdit;
        _crud.init(config);

        _me.eform = $('#eform');
        //other variables
        //_me.divSignRows = $('#divSignRows');
    },

    //TODO: add your code
    //onclick viewFile, called by XiFile component
    onViewFile: function (fid, elm) {
        _edit.viewImage('', fid, elm, _itext.get('LeaveId', _me.eform));
    },

    onSubmit: function () {
        var form = _me.eform;
        var data = {
            id: _itext.get('SignId', form),
            status: _iselect.get('SignStatus', form),
            note: _itext.get('Note', form),
        };
        _ajax.getJson('SignRow', data, function (data) {
            _crud.afterSave(data);
        });
    },

    /*
    edit0_afterOpenEdit: function (fun, json) {
        //alert('edit0_afterOpenEdit');
        var box = _me.divSignRows;
        if (fun == _fun.FunC) {
            box.empty();
        } else {
            _ajax.getView('SignRows', { id: _me.edit0.getKey() }, function (html) {
                box.html(html);
            });
        }
    },
    */

}; //class