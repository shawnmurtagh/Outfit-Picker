using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Outfit_Picker.Models;
using Outfit_Picker.ViewModels;

namespace Outfit_Picker.Controllers
{
    public class OutfitsController : Controller
    {
        private Outfit_PickerContext db = new Outfit_PickerContext();

        // GET: Outfits
        public ActionResult Index()
        {
            var outfits = db.Outfits.Include(o => o.Bottom).Include(o => o.Shoe).Include(o => o.Top);
            return View(outfits.ToList());
        }

        // GET: Outfits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            return View(outfit);
        }

        // GET: Outfits/Create
        public ActionResult Create()
        {
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "BottomName");
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "ShoeName");
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "TopName");


            OutfitViewModel outfitViewModel = new OutfitViewModel
            {

                //Looks up all acessories then 
                AllAccessories = (from a in db.Accessories
                                  select new SelectListItem
                                  {
                                      Value = a.AccessoryID.ToString(),
                                      Text = a.AccessoryName
                                  })


            };

            return View(outfitViewModel);
        }

        // POST: Outfits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OutfitID,OutfitName,TopID,BottomID,ShoeID")] Outfit outfit, List <int> AllAccessories)
        {
            if (ModelState.IsValid)
            {
                //Changing the entity will not longer work
                //db.Entry(outfit).State = EntityState.Modified;

                //Place the data for new outfit we bound into the variable "newOutfit"
                var newOutfit = db.Outfits.Add(outfit);

                //Place the data from the top, bottom, and shoes we bound into the new outfit
                newOutfit.TopID = outfit.TopID;
                newOutfit.BottomID = outfit.BottomID;
                newOutfit.ShoeID = outfit.ShoeID;

                //loop through each accessory that was bound
                foreach (int accessoryID in AllAccessories)
                {
                    //find the accessory by its ID and add it to the new outfit
                    newOutfit.Accessories.Add(db.Accessories.Find(accessoryID));
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //If invalid it runs code below

            
                ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "BottomName");
                ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "ShoeName");
                ViewBag.TopID = new SelectList(db.Tops, "TopID", "TopName");


                OutfitViewModel outfitViewModel2 = new OutfitViewModel
                {

                    //Looks up all acessories then 
                    AllAccessories = (from a in db.Accessories
                                      select new SelectListItem
                                      {
                                          Value = a.AccessoryID.ToString(),
                                          Text = a.AccessoryName

                                      })


                };

                return View(outfitViewModel2);
            }



        // GET: Outfits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }


            var outfitViewModel = new OutfitViewModel
            {
                Outfit = outfit,
                AllAccessories = from a in db.Accessories
                                 select new SelectListItem
                                 {
                                     Text = a.AccessoryName,
                                     Value = a.AccessoryId.ToString()
                                 }
            };

            
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "BottomName", outfit.BottomID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "ShoeName", outfit.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "TopName", outfit.TopID);

            

            return View(outfitViewModel);
            //return View();
        }

        // POST: Outfits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OutfitID,OutfitName,TopID,BottomID,ShoeID")] Outfit outfit, List<int> AllAccessories)
        {
            if (ModelState.IsValid)
            {
                //Changing the entity will not longer work
                //db.Entry(outfit).State = EntityState.Modified;

                //Place the data for the assigned outfit into a variable "existing..."
                var existingOutfit = db.Outfits.Find(outfit.OutfitID);

                //assigning the data bound form user to the variable we created above
                existingOutfit.TopID = outfit.TopID;
                existingOutfit.BottomID = outfit.BottomID;
                existingOutfit.ShoeID = outfit.ShoeID;

                //Wipe out all previous accessory choices so no need for logic to determine which
                //accessories the user previously chose vs. currently chose
                existingOutfit.Accessories.Clear();

                foreach(int accessoryID in AllAccessories)
                {
                    //find the accessory by its ID and add it to the existing outfit
                    existingOutfit.Accessories.Add(db.Accessories.Find(accessoryID));
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //If invalid it runds code below

            var outfitViewModel = new OutfitViewModel
            {
                Outfit = outfit,
                AllAccessories = from a in db.Accessories
                                 select new SelectListItem
                                 {
                                     Text = a.AccessoryName,
                                     Value = a.AccessoryId.ToString()
                                 }
            };


            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "BottomName", outfit.BottomID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "ShoeName", outfit.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "TopName", outfit.TopID);



            return View(outfitViewModel);
        }

        // GET: Outfits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            return View(outfit);
        }

        // POST: Outfits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Outfit outfit = db.Outfits.Find(id);
            db.Outfits.Remove(outfit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
