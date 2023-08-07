var currentAction = "";
$(function () {
  let url = "/PaymentType/GetPaymentTypes";
  // AJAX call to fetch PaymentType data
  renderEjGrid(url);
});
function rowBound(args) {
  if (args.data["Status"] == 1) {
    args.row[0].cells[3].innerText = "Active";
  } else {
    args.row[0].cells[3].innerText = "Inactive";
  }
  if (args.data["CreationDate"] != null && args.row[0].cells[6]) {
    var jsonDate = args.row[0].cells[6].innerText;
    var dateObject = parseJsonDate(jsonDate);
    args.row[0].cells[6].innerText = dateObject;
    // console.log(dateObject);
  }
}
function addButtonAction(args) {
  console.log("hello", args.model);
}
function deleteButtonAction(args) {
  args.cancel = true;
  let fetchurl = "/PaymentType/GetPaymentTypes";
  // console.log(args);
  let id = args.data.Id;
  $.ajax({
    url: "/Admin/PaymentType/Delete/" + id, // Replace with the actual URL for your delete action
    method: "POST",
    success: function (data) {
      // Handle the success response from the server
      console.log("Record deleted successfully:", data);

      renderEjGrid(fetchurl);
    },
    error: function (error) {
      // Handle the error response from the server
      console.error("Error deleting record:", error);
    },
  });
}

function saveButtonAction(args) {
  if (args.requestType === "save" && currentAction == "create") {
    var formData = $("#GridEditForm").serialize();
    var formDataObject = parseQueryString(formData);
    // Make an AJAX POST request to the create action
    $.ajax({
      url: "/Admin/PaymentType/Create", // Replace with the actual URL for your create action
      method: "POST",
      data: formDataObject, // The JavaScript object containing form data
      success: function (data) {
        // Handle the success response from the server
        let fetchurl = "/PaymentType/GetPaymentTypes";

        console.log("Create action successful:", data);

        renderEjGrid(fetchurl);
        currentAction = "";
      },
      error: function (error) {
        // Handle the error response from the server
        console.error("Error in create action:", error);
      },
    });
  }
  if (args.requestType === "save" && currentAction == "edit") {
    var formData = $("#GridEditForm").serialize();
    var formDataObject = parseQueryString(formData);
    formDataObject.Id = args.rowData.Id;
    // Make an AJAX POST request to the create action
    $.ajax({
      url: "/Admin/PaymentType/Edit", // Replace with the actual URL for your create action
      method: "POST",
      data: formDataObject, // The JavaScript object containing form data
      success: function (data) {
        // Handle the success response from the server
        let fetchurl = "/PaymentType/GetPaymentTypes";

        console.log("Edit action successful:", data);

        renderEjGrid(fetchurl);
        currentAction = "";
      },
      error: function (error) {
        // Handle the error response from the server
        console.error("Error in edit action:", error);
      },
    });
  }
}

function complete(args) {
  if (args.requestType == "beginedit" || args.requestType == "add") {
    if (args.requestType == "add") {
      // console.log("Add Action Triggered", this);
      $("#" + this._id + "_dialogEdit").ejDialog({
        title: "Add New Payment Type",
      });
      $("#GridCreatedBy").parent().parent().hide();
      $("#GridCreationDate").parent().parent().hide();
      currentAction = "create";
    } else {
      $("#" + this._id + "_dialogEdit").ejDialog({
        title: "Edit Payment Type",
      });
      // console.log("Edit Action Triggered", args);
      $("#GridCreatedBy").parent().parent().hide();
      $("#GridCreationDate").parent().parent().hide();
      currentAction = "edit";
    }
  }
}

function parseQueryString(queryString) {
  var params = {};
  var pairs = queryString.split("&");

  for (var i = 0; i < pairs.length; i++) {
    var pair = pairs[i].split("=");
    var key = decodeURIComponent(pair[0]);
    var value = decodeURIComponent(pair[1]);
    params[key] = value;
  }

  return params;
}

function cancelButtonAction(args) {
  args.cancel = true;
  currentAction = "";
}

function renderEjGrid(api) {
  $.ajax({
    url: api,
    method: "GET",
    dataType: "json",
    success: function (data) {
      // Initialize EJ2 Grid with the fetched PaymentType data
      // console.log("received data from the server, payment types : ", data);

      $("#Grid").ejGrid({
        dataSource: ej.DataManager({
          json: data, // Use the fetched PaymentType data
          adaptor: new ej.remoteSaveAdaptor(),
          insertUrl: "", // Specify the insert URL
          updateUrl: "", // Specify the update URL
          removeUrl: "", // Specify the remove URL
        }),
        loadingIndicator: { indicatorType: "Shimmer" },
        toolbarSettings: {
          showToolbar: true,
          toolbarItems: [
            "add",
            "edit",
            "delete",
            "cancel",
            "search",
            "printGrid",
          ],
        },
        editSettings: {
          allowEditing: true,
          allowAdding: true,
          allowDeleting: true,
          showDeleteConfirmDialog: true,
          showAddNewDialog: true,
          editMode: "dialog",
        },
        isResponsive: true,
        enableResponsiveRow: true,
        allowSorting: true,
        allowSearching: true,
        allowFiltering: true,
        filterSettings: {
          filterType: "excel",
          maxFilterChoices: 100,
          enableCaseSensitivity: false,
        },
        allowPaging: true,
        pageSettings: {
          pageSize: 10,
          printMode: ej.Grid.PrintMode.CurrentPage,
        },
        columns: [
          {
            field: "Id",
            headerText: "Payment Type Id",
            isPrimaryKey: true,
            isIdentity: true,
            visible: false,
          },
          {
            field: "Name",
            headerText: "Payment Type Name",
            validationRules: { required: true },
          },
          {
            field: "Description",
            headerText: "Description",
            validationRules: {
              required: true,
              //customRule: function (value, column, record) {
              //    // Define your custom validation logic here
              //    // For example, let's say you want the description to be at least 5 characters long
              //    console.log(value);
              //},
              //customMessage: "Description must be at least 5 characters long.",
            },
            allowSorting: false,
            width: 220,
          },
          {
            field: "Status",
            headerText: "Status",
            allowSorting: false,
            editType: "numericedit",
            defaultValue: 1,
          },
          { field: "Rank", headerText: "Rank", editType: "numericedit" },
          { field: "CreatedBy", headerText: "CreatedBy", allowSorting: false },
          { field: "CreationDate", headerText: "Creation Date" },
        ],
        actionComplete: "complete",
        actionBegin: function (args) {
          switch (args.requestType) {
            case "save":
              saveButtonAction(args);
              break;
            case "delete":
              deleteButtonAction(args);
              break;
            case "add":
              addButtonAction(args);
              break;
            case "edit":
              editButtonAction(args);
              break;
            case "cancel":
              cancelButtonAction(args);
              break;
          }
        },
        rowDataBound: rowBound,
      });
    },
    error: function (error) {
      console.error("Error fetching payment types:", error);
    },
  });
}

function parseJsonDate(jsonDate) {
  // Extract the timestamp from the JSON date format
  var timestamp = parseInt(jsonDate.substr(6));
  var currentDate = new Date(timestamp);
  // Create a new Date object using the timestamp
  const formattedDate = formatDate(currentDate);

  return formattedDate;
}
function formatDate(date) {
  const months = [
    "Jan",
    "Feb",
    "Mar",
    "Apr",
    "May",
    "Jun",
    "Jul",
    "Aug",
    "Sep",
    "Oct",
    "Nov",
    "Dec",
  ];

  const day = date.getDate().toString().padStart(2, "0");
  const month = months[date.getMonth()];
  const year = date.getFullYear().toString().slice(-2);

  return `${day}-${month}-${year}`;
}