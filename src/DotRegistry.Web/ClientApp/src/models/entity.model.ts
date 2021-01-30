export interface Entity {
  /**
  * Flag to determine if the current entity was "soft" deleted
  */
  active: boolean;
  /**
  * When this entity was created
  */
  createdAt: Date;
  /**
  * The unique slug identifying this entity
  */
  slug: string;

  /**
  * When this entity was last updated
  */
  updatedAt?: Date;
}
