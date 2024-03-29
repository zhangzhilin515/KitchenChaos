using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    public override void Interact(Player player)
    {
        if(!HasKitchenObject())
        {
            //There is no KitchenObject here
            if(player.HasKitchenObject())
            {
                //Player is carring something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //Player not carring anything
            }
        }
        else
        {
            //There is a KitchenObject here
            if(player.HasKitchenObject())
            {
                //Player is carrying something
                if(player.GetKitchenObject().TrtGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    //Player is carrying a plate
                    if(plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
            }
            else
            {
                //Player is not carring anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

}
