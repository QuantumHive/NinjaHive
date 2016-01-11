﻿// ninjaHive namespace
var ninjaHive = ninjaHive || {};

// ninjaHive.categoryPage namespace
ninjaHive.categoryPage = ninjaHive.categoryPage || {};

(function () {
    var categoryPage = function () {
        var CP                                  = this;

        // event tracking
        var lastMainCategory                    = null;
        var lastSubCategory                     = null;

        // global variables to let modification from outside the namespace
        this.subCategoryFormClassName           = null;
        this.mainCategoryFormIdName             = null;
        this.subCategoryGroupClassName          = null;

        this.deleteUrl                          = null;
        this.editUrl                            = null;
        this.getGameItemsUrl                    = null;

        this.MainCategoryNode = function (domElement) {
            var _domElement = domElement;
            var _editing = false;
            
            this.isEditing = function () {
                return _editing;
            }

            this.toDomElement = function () {
                return _domElement;
            }            

            this.activate = function () {
                if (_domElement.className.search(" active") == -1) {
                    _domElement.className += " active";
                }
            }

            this.deactivate = function () {                
                _domElement.className = _domElement.className.replace(" active", "");
            }

            this.startEdit = function () {
                _editing = true;

                for (var i = 0; i < _domElement.children.length; i++) {
                    if (_domElement.children[i].className == "input" || _domElement.children[i].className == "input active") {
                        _domElement.children[i].style.display = "inline";
                    } else if (_domElement.children[i].className == "name" || _domElement.children[i].className == "name active") {
                        _domElement.children[i].style.display = "none";
                    }
                }
            }

            this.saveEdit = function () {
                var HttpRequest = new XMLHttpRequest();
            }

            this.httpEdit = function () {

            }

            this.httpDelete = function () {

            }

            this.endEdit = function () {
                _editing = false;

                for (var i = 0; i < _domElement.children.length; i++) {
                    if (_domElement.children[i].className == "input" || _domElement.children[i].className == "input active") {
                        _domElement.children[i].style.display = "none";
                    } else if (_domElement.children[i].className == "name" || _domElement.children[i].className == "name active") {
                        _domElement.children[i].style.display = "inline";
                    }
                }
            }

            this.hideSubCategoryForm = function () {
                var elements = document.getElementsByClassName(CP.subCategoryFormClassName);

                for (var i = 0; i < elements.length; i++) {
                    if (elements[i].getAttribute("data-parent-id") == _domElement.getAttribute("data-id")) {
                        CP.SubCategoryForm(elements[i]).hide();
                    }
                }
            }

            this.showSubCategoryForm = function() {
                var elements = document.getElementsByClassName(CP.subCategoryFormClassName);

                for (var i = 0; i < elements.length; i++) {                    
                    if (elements[i].getAttribute("data-parent-id") == _domElement.getAttribute("data-id")) {
                        CP.SubCategoryForm(elements[i]).show();
                    }
                }
            }

            this.getSubCategoryForm = function () {
                var elements = document.getElementsByClassName(CP.subCategoryFormClassName);
                var result = [];

                for (var i = 0; i < elements.length; i++) {
                    if (elements[i].getAttribute("data-parent-id") == _domElement.getAttribute("data-id")) {
                        result.push(new CP.SubCategoryForm(elements[i]));
                    }
                }

                return result[0];
            }

            //this.onclick = function () {
            //    CP.hideAllSubCategoriesForm(document.getElementsByClassName(CP.subCategoryFormClassName));

            //    this.activate();
            //    this.showSubCategoryForm();
            //}

            return this;
        };

        this.MainCategoryForm = function (domElement) {
            var _domElement = domElement;

            this.hide = function () {
                _domElement.style.visibility = "hidden";
            }

            this.show = function () {
                _domElement.style.visibility = "visible";
            }

            this.getChildren = function () {
                var result = [];

                for (var i = 0; i < _domElement.children.length; i++) {
                    result.push(new CP.MainCategoryNode(_domElement.children[i]));
                }

                return result;
            }

            return this;
        };

        this.SubCategoryNode = function (domElement) {            
            var _domElement = domElement;
            var _editing = false;


            
            this.equals = function (other) {
                if (typeof other != typeof this) {                   
                    throw new TypeError("SubCategoryNode::equals - @param other is not of type SubCategoryNode");
                    return false;
                }

                return _domElement.getAttribute("data-id") == other.toDomElement().getAttribute("data-id");
            }

            this.isEditing = function () {
                return _editing;
            }

            this.toDomElement = function () {
                return _domElement;
            }

            this.activate = function () {
                if (_domElement.className.search(" active") == -1) {
                    _domElement.className += " active";
                }
            }

            this.deactivate = function () {
                _domElement.className = _domElement.className.replace(" active", "");
            }

            this.show = function () {
                _domElement.style.display = "block";
            }

            this.hide = function () {
                _domElement.style.display = "none";
            }

            this.saveEdit = function () {
                var nameElement;
                var inputElement;

                for (var i = 0; i < _domElement.children.length; i++) {
                    if (_domElement.children[i].className == "input" || _domElement.children[i].className == "input active") {
                        inputElement = _domElement.children[i].children[0];
                    } else if (_domElement.children[i].className == "name" || _domElement.children[i].className == "name active") {
                        nameElement = _domElement.children[i];
                    }
                }

                if (inputElement.value.length > 0) {
                    nameElement.innerHTML = inputElement.value;
                }
            }

            this.startEdit = function () {
                // avoid useless operations if is already in edit mode
                //if (_editing == true) {
                //    return;
                //}

                _editing = true;

                var inputElement;
                var nameElement;

                for (var i = 0; i < _domElement.children.length; i++) {
                    if (_domElement.children[i].className == "input" || _domElement.children[i].className == "input active") {
                        inputElement = _domElement.children[i];
                        inputElement.style.display = "inline";

                        inputElement = inputElement.children[0];
                    } else if (_domElement.children[i].className == "name" || _domElement.children[i].className == "name active") {
                        nameElement = _domElement.children[i];
                        nameElement.style.display = "none";
                    }
                }

                // this is only to improve the appareance
                inputElement.value = "";
                inputElement.placeholder = nameElement.innerHTML;
                inputElement.focus();
            }

            this.endEdit = function () {
                // avoid useless operations if not needed
                //if (_editing == false) {
                //    return;
                //}

                _editing = false;

                for (var i = 0; i < _domElement.children.length; i++) {
                    if (_domElement.children[i].className == "input" || _domElement.children[i].className == "input active") {
                        _domElement.children[i].style.display = "none";
                    } else if (_domElement.children[i].className == "name" || _domElement.children[i].className == "name active") {
                        _domElement.children[i].style.display = "inline";
                    }
                }
            }

            // want to keep a separation between client saving and 
            // server side databse uploading
            this.httpEdit = function () {
                var elementId = _domElement.getAttribute("data-id");
                var mainId = _domElement.getAttribute("data-parent-id");
                var elementName; 

                for (var i = 0; i < _domElement.children.length; i++) {
                   if (_domElement.children[i].className == "name" || _domElement.children[i].className == "name active") {
                       elementName = _domElement.children[i];
                    }
                }                               

                var http = new XMLHttpRequest();
                http.open("POST", CP.editUrl);

                var data = new FormData();
                data.append("Id", elementId);
                data.append("Name", elementName.innerHTML);
                data.append("MainCategoryId", mainId);

                http.send(data);
            }

            this.httpDelete = function (successCallback, failureCallback) {
                var elementId = _domElement.getAttribute("data-id");

                // first check
                var check = new XMLHttpRequest();
                check.open("POST", CP.getGameItemsUrl);

                var checkData = new FormData();
                checkData.append("Id", elementId);

                check.onload = function () {
                    var toCheck = check.response;

                    toCheck = toCheck.toString().slice(1);
                    toCheck = toCheck.toString().slice(0, toCheck.toString().search("]"));

                    if (toCheck == null || toCheck.length > 0) {
                        failureCallback();
                        return;
                    }

                    var mainId = _domElement.getAttribute("data-parent-id");
                    var elementName;

                    for (var i = 0; i < _domElement.children.length; i++) {
                        if (_domElement.children[i].className == "name" || _domElement.children[i].className == "name active") {
                            elementName = _domElement.children[i];
                        }
                    }

                    var http = new XMLHttpRequest();
                    http.open("POST", CP.deleteUrl);

                    var data = new FormData();
                    data.append("Id", elementId);
                    data.append("IsMainCategory", false);

                    http.send(data);

                    successCallback();
                }

                check.send(checkData);
            }

            return this;
        };

        this.SubCategoryForm = function (domElement) {
            var _domElement = domElement;

            this.hide = function () {
                _domElement.style.display = "none";
            }

            this.show = function () {
                _domElement.style.display = "block";
            }

            this.showSubCategories = function () {
                var elements = document.getElementsByClassName(CP.subCategoryGroupClassName);

                for (var i = 0; i < elements.length; i++) {
                    if (elements[i].getAttribute("data-parent-id") == _domElement.getAttribute("data-parent-id")) {
                        CP.SubCategoryNode(elements[i]).show();
                    }
                }
            }

            this.hideSubCategories = function () {
                var elements = document.getElementsByClassName(CP.subCategoryGroupClassName);

                for (var i = 0; i < elements.length; i++) {
                    if (elements[i].getAttribute("data-parent-id") == _domElement.getAttribute("data-parent-id")) {
                        CP.SubCategoryNode(elements[i]).hide();
                    }
                }
            }

            return this;
        }

        this.deactivateAllMainCategories = function () {
            var elements = document.getElementsByClassName(CP.mainCategoryFormIdName);

            for (var i = 0; i < elements.length; i++) {
                CP.MainCategoryNode(elements[i]).deactivate();
            }
        }

        this.hideAllSubCategoryForms = function () {
            var elements = document.getElementsByClassName(CP.subCategoryFormClassName);

            for (var i = 0; i < elements.length; i++) {
                CP.SubCategoryForm(elements[i]).hide();
            }          
        }

        this.hideAllSubCategories = function () {
            var elements = document.getElementsByClassName(CP.subCategoryFormClassName);

            for (var i = 0; i < elements.length; i++) {
                CP.SubCategoryForm(elements[i]).hideSubCategories();
            }
        }

        // MainCategory event handling global functions

        this.onMainCategoryClick = function (sender) {            
            var mainCategory = new ninjaHive.categoryPage.MainCategoryNode(sender);
     
            if (lastMainCategory != null) {
                if (lastMainCategory.toDomElement() != mainCategory.toDomElement()) {
                    lastMainCategory.getSubCategoryForm().hideSubCategories();
                    lastMainCategory.hideSubCategoryForm();
                    lastMainCategory.endEdit();
                    //lastMainCategory.deactivate();
                }
            } else {
                CP.hideAllSubCategoryForms();
                CP.hideAllSubCategories();
            }

            //mainCategory.activate();
            mainCategory.getSubCategoryForm().showSubCategories();
            mainCategory.showSubCategoryForm();

            lastMainCategory = mainCategory;
        }

        this.onMainCategoryEdit = function(sender) {
            var mainCategory = new ninjaHive.categoryPage.MainCategoryNode(sender);
            mainCategory.startEdit();

            if (lastMainCategory != null) {
                if (lastMainCategory.toDomElement() != mainCategory.toDomElement()) {
                    lastMainCategory.getSubCategoryForm().hideSubCategories();
                    lastMainCategory.hideSubCategoryForm();
                    lastMainCategory.endEdit();
                    //lastMainCategory.deactivate();
                }
            } else {
                CP.hideAllSubCategoryForms();
                CP.hideAllSubCategories();
            }

            mainCategory.getSubCategoryForm().showSubCategories();
            mainCategory.showSubCategoryForm();
            //mainCategory.activate();

            lastMainCategory = mainCategory;
        }

        this.onMainCategoryDelete = function (sender) {

        }

        
        // SubCategory event handling global functions

        // this is a bit tricky due the fact that the onClick event
        // is called on both parent and child elements 
        //
        // TODO: look for a better implementation, even if this one shouldn't
        // represent a big overhead
        this.onSubCategoryClick = function (sender) {
            var subCategory = new CP.SubCategoryNode(sender);

            if (lastSubCategory != null && lastSubCategory != -1) {
                if (!lastSubCategory.equals(subCategory)) {

                    if (lastSubCategory.isEditing() == true) {
                        lastSubCategory.endEdit();
                    }

                    subCategory.startEdit();
                } else {
                    if (lastSubCategory.isEditing() == false) {
                        lastSubCategory.startEdit();
                    }

                    return;
                }
            } else if (lastSubCategory != -1) {
                if (subCategory.isEditing() == false) {
                    subCategory.startEdit();
                }
            }

            subCategory.activate();
            lastSubCategory = subCategory;
        }

        this.onSubCategorySaveEdit = function (sender) {
            var subCategory = new CP.SubCategoryNode(sender);
            subCategory.endEdit();
            subCategory.saveEdit();
            subCategory.httpEdit();

            lastSubCategory = -1;
        }

        this.onSubCategoryDelete = function (sender) {
            // implement server comunication
            var subCategory = new CP.SubCategoryNode(sender);
            subCategory.httpDelete(
                function () {
                    subCategory.toDomElement().remove();
                }, 
                
                function () {
                    var alertDialog = ninjaHive.modal.alertDialog("Cannot Complete", "Cannot delete category because it is linked to game items", false);
                    alertDialog.setDynamicContent(data);
                }
            );
        }

        return this;
    };

    ninjaHive.categoryPage = new categoryPage();
})();

