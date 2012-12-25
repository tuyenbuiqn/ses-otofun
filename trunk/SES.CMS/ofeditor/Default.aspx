<%@ Page Title="" Language="C#" MasterPageFile="~/ofeditor/Editor.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SES.CMS.ofeditor.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div id="main">
                    
                    <div class="pad20">
                        <!-- Tabs -->
                        
                      
                                <!-- Fieldset -->
                                <fieldset>
                                    <legend>This is a simple fieldset</legend>
                                    <p>
                                        <label for="sf">
                                            Small field:
                                        </label>
                                        <input class="sf" name="sf" type="text" value="small input field" />
                                        <span class="field_desc">Field description</span>
                                    </p>
                                    <p>
                                        <label for="mf">
                                            Medium Field:
                                        </label>
                                        <input class="mf" name="mf" type="text" value="medium input field" />
                                        <span class="validate_success">A positive message!</span>
                                    </p>
                                    <p>
                                        <label for="lf">
                                            Large Field:
                                        </label>
                                        <input class="lf" name="lf" type="text" value="large input field" />
                                        <span class="validate_error">A negative message!</span>
                                    </p>
                                    <p>
                                        <label>
                                            Linecheckboxes:
                                        </label>
                                        <input type="checkbox" />Lorem Ipsum
                                        <input type="checkbox" />Lorem Ipsum
                                        <input type="checkbox" />Lorem Ipsum
                                        <input type="checkbox" />Lorem Ipsum
                                    </p>
                                    <p>
                                        <label for="dropdown">
                                            DropDown:
                                        </label>
                                        <select name="dropdown" class="dropdown">
                                            <option>Please select an option</option>
                                            <option>Upload</option>
                                            <option>Change</option>
                                            <option>Remove</option>
                                        </select>
                                    </p>
                                    <p>
                                        <label>
                                            Vertical:</label>
                                        <div class="inpcol">
                                            <p>
                                                <input type="checkbox" />Lorem Ipsum</p>
                                            <p>
                                                <input type="checkbox" />Lorem Ipsum</p>
                                            <p>
                                                <input type="checkbox" />Lorem Ipsum</p>
                                            <p>
                                                <input type="checkbox" />Lorem Ipsum</p>
                                        </div>
                                        <div class="inpcol">
                                            <p>
                                                <input type="radio" />Lorem Ipsum</p>
                                            <p>
                                                <input type="radio" />Lorem Ipsum</p>
                                            <p>
                                                <input type="radio" />Lorem Ipsum</p>
                                            <p>
                                                <input type="radio" />Lorem Ipsum</p>
                                        </div>
                                    </p>
                                    <p>
                                        <!-- WYSIWYG editor -->
                                        <textarea cols="80" rows="10" class="wysiwyg"></textarea>
                                        <!-- End of WYSIWYG editor -->
                                    </p>
                                    <p>
                                        <input class="button" type="submit" value="Submit" />
                                        <input class="button" type="reset" value="Reset" />
                                    </p>
                                </fieldset>
                                

                                <table class="fullwidth" cellpadding="0" cellspacing="0" border="0">
                                    <thead>
                                        <tr>
                                            <td>
                                                <input type="checkbox" class="checkall" />
                                            </td>
                                            <td>
                                                Name
                                            </td>
                                            <td>
                                                E-Mail
                                            </td>
                                            <td>
                                                Birthdate
                                            </td>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr class="odd">
                                            <td>
                                                <input type="checkbox" />
                                            </td>
                                            <td>
                                                Johnatan Doe
                                            </td>
                                            <td>
                                                johndoe@someservice.web
                                            </td>
                                            <td>
                                                28/09/1978
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <input type="checkbox" />
                                            </td>
                                            <td>
                                                Johnatan Doe
                                            </td>
                                            <td>
                                                johndoe@someservice.web
                                            </td>
                                            <td>
                                                28/09/1978
                                            </td>
                                        </tr>
                                        <tr class="odd">
                                            <td>
                                                <input type="checkbox" />
                                            </td>
                                            <td>
                                                Johnatan Doe
                                            </td>
                                            <td>
                                                johndoe@someservice.web
                                            </td>
                                            <td>
                                                28/09/1978
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <input type="checkbox" />
                                            </td>
                                            <td>
                                                Johnatan Doe
                                            </td>
                                            <td>
                                                johndoe@someservice.web
                                            </td>
                                            <td>
                                                28/09/1978
                                            </td>
                                        </tr>
                                        <tr class="odd">
                                            <td>
                                                <input type="checkbox" />
                                            </td>
                                            <td>
                                                Johnatan Doe
                                            </td>
                                            <td>
                                                johndoe@someservice.web
                                            </td>
                                            <td>
                                                28/09/1978
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <input type="checkbox" />
                                            </td>
                                            <td>
                                                Johnatan Doe
                                            </td>
                                            <td>
                                                johndoe@someservice.web
                                            </td>
                                            <td>
                                                28/09/1978
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                        <!-- End of Tabs -->
                    </div>
                    <hr />
                </div>
</asp:Content>
