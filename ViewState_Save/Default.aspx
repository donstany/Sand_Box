<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  // Sample ArrayList for the page.
  ArrayList PageArrayList;

  ArrayList CreateArray()
  {
    // Create a sample ArrayList.
    ArrayList result = new ArrayList(4);
    
    result.Add("item 1");
    result.Add("item 2");
    result.Add("item 3");
    result.Add("item 4");
    
    return result;
  }

  void Page_Load(object sender, EventArgs e)
  {
    if (ViewState["arrayListInViewState"] != null)
    {
      PageArrayList = (ArrayList)ViewState["arrayListInViewState"];
    }
    else
    {
      // ArrayList isn't in view state, so we need to load it from scratch.
      PageArrayList = CreateArray();
    }
    // Code that uses PageArrayList.
  }
    
  void Page_PreRender(object sender, EventArgs e)
  {
    // Save PageArrayList before the page is rendered.
    ViewState.Add("arrayListInViewState", PageArrayList);
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>View state sample</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>